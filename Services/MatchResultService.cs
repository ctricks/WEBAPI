using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.MatchResult;

namespace WEBAPI.Services
{
    public interface IMatchResultService
    {
        IEnumerable<MatchResultConfig> GetAll();

        void SetDefault();
        MatchResultConfig GetById(int id);
        void Create(UpdateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class MatchResultService : IMatchResultService
    {
        private DataContext _context;
        private readonly IMapper _mapper;        

        public MatchResultService(
            DataContext context,
                IMapper mapper
                )
        {
            _context = context;
            _mapper = mapper;            
        }
        public void Create(UpdateRequest model)
        {
            //CB-10042023 Validate if exist value
            if (_context.MatchResultConfigs.Any(x => x.Result == model.Result))
                throw new AppException("Result is already exists. Please check your entry");

            var adminuser = getUserAdmin(model.TokenId);

            if (adminuser == null)
                throw new AppException("User not allowed to do this. Please use administration account");

            _context.MatchResultConfigs.Add(new MatchResultConfig() { Result = model.Result });
            _context.SaveChanges();
        }

        public IEnumerable<MatchResultConfig> GetAll()
        {
            return _context.MatchResultConfigs;
        }

        public void SetDefault()
        {
            //CB-10042023 For migration uses Truncate Table and call this for default values
            //Check if exists            
            string[] StatusValues = new string[] { "WHITE WINS", "RED WINS", "DRAW", "CANCELLED" };

            object? matchResult;

            foreach (string statVal in StatusValues)
            {
                matchResult = _context.MatchResultConfigs.Where(x => x.Result == statVal).FirstOrDefault();
                if (matchResult == null)
                    _context.MatchResultConfigs.Add(new MatchResultConfig { Result = statVal });
            }

            _context.SaveChanges();

        }


        public MatchResultConfig GetById(int id)
        {
            return getMatchResult(id);
        }

        public void Update(int id, UpdateRequest model)
        {
            var matchResult = getMatchResult(id);

            if (matchResult == null)
                throw new AppException("Result not exists. Please check your entry");


            // copy model to user and save
            _mapper.Map(model, matchResult);
            _context.MatchResultConfigs.Update(matchResult);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var matchResult = getMatchResult(id);
            _context.MatchResultConfigs.Remove(matchResult);
            _context.SaveChanges();
        }
        private MatchResultConfig getMatchResult(int id)
        {
            var matchResult = _context.MatchResultConfigs.Find(id);
            if (matchResult == null) throw new KeyNotFoundException("Match Result not found");
            return matchResult;
        }
        private UserAdmin getUserAdmin(string TokenId)
        {
            var user = _context.UserAdmins.Where(x => x.TokenID == TokenId).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("Please use Admin Account.");
            return user;
        }
    }
}
