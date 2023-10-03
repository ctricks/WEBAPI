﻿using AutoMapper;
using WEBAPI.Authorization;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.Users;

namespace WEBAPI.Services
{
    public interface IUserAdminService
    {
        AdminAuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserAdmin> GetAll();
        UserAdmin GetById(int id);
        void Register(AdminRegisterRequest model);
        //void Update(int id, UpdateRequest model);
        void Delete(int id);
        void Logout(int id);
    }

    public class UserAdminService : IUserAdminService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserAdminService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AdminAuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var useradmin = _context.UserAdmins.SingleOrDefault(x => x.UserName == model.Username);

            // validate
            if (useradmin == null || !BCrypt.Net.BCrypt.Verify(model.Password, useradmin.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AdminAuthenticateResponse>(useradmin);
            response.Token = _jwtUtils.GenerateTokenAdmin(useradmin);

            //CB-09302023 Update TokenID in UserTable
            //_mapper.Map(model, user);
            useradmin.TokenID = response.Token;

            _context.UserAdmins.Update(useradmin);
            _context.SaveChanges();

            return response;
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            return _context.UserAdmins;
        }

        public UserAdmin GetById(int id)
        {
            return getUser(id);
        }

        public void Register(AdminRegisterRequest model)
        {
            // validate
            if (_context.UserAdmins.Any(x => x.UserName == model.UserName))
                throw new AppException("Username '" + model.UserName + "' is already taken");

            // map model to new user object
            var useradmin = _mapper.Map<UserAdmin>(model);

            // hash password
            useradmin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            
            // save user
            _context.UserAdmins.Add(useradmin);

            _context.SaveChanges();
        }

        public void Logout(int id)
        {
            //CB-09302023 Get User via id
            var user = getUser(id);
            user.TokenID = null;
            _context.UserAdmins.Update(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.UserName && _context.Users.Any(x => x.UserName == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.UserAdmins.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.UserAdmins.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private UserAdmin getUser(int id)
        {
            var user = _context.UserAdmins.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

    }
}