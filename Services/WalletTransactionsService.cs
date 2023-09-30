using AutoMapper;
using WEBAPI.Authorization;
using WEBAPI.Entities;
using WEBAPI.Helpers;
using WEBAPI.Models.WalletTransactions;

namespace WEBAPI.Services
{
    public interface IWalletTransactionsService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<WalletTxn> GetAll();
        WalletTxn GetById(int id);
        void Create(RegisterRequest model);
        //void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class WalletTransactionsService : IWalletTransactionsService
    {
        private DataContext _context;        
        private readonly IMapper _mapper;

        public WalletTransactionsService(
            DataContext context,          
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //CB-09302023 Check UserCreds via TokenID, if user has null token in database... you need to login first
            var user = _context.Users.SingleOrDefault(x => x.TokenID == model.TokenID);

            // validate
            if (user == null)
                throw new AppException("User is not login. Please login again");

            var response = _mapper.Map<AuthenticateResponse>(user);

            //response.Message = "Wallet Transaction successfully granted";

            return response;
        }

        public IEnumerable<WalletTxn> GetAll()
        {
            return _context.WalletTxns;
        }

        public WalletTxn GetById(int id)
        {
            return getWallet(id);
        }

        public void Create(RegisterRequest model)
        {
            //CB-09292023 user TokenID 
            //Validate tokenID via user
            if (!_context.Users.Any(x => x.TokenID == model.UserTokenID))
                throw new AppException("TokenID is not found. Please login first");

            // save wallet Transactions
            WalletTxn wallettrans = new WalletTxn();

            wallettrans.amount = model.available_balance;
            wallettrans.account_bal = model.total_balance;
            wallettrans.TokenID = model.UserTokenID;
            wallettrans.TransactionType = model.TransactionType;

            var userinfo = getUsersViaToken(model.UserTokenID);

            //CB-09302023 Update the Userwallet then the wallet transaction as Additional
            UserWallet userwallet = new UserWallet();
            userwallet.WalletTrans = new List<WalletTxn>();
            userwallet.WalletTrans.Add(wallettrans);
            userwallet.available_balance = model.available_balance;
            userwallet.total_balance = model.total_balance;
            userwallet.UserId = userinfo.Id;
            
            if (userinfo == null)
                throw new AppException("Token is invalid. Please login");

            var UserWallet = getUWallet(userinfo.Id);

            if (userinfo == null)
            {
                _context.UserWallet.Add(userwallet);
            }
            else
            {                
                _context.UserWallet.Update(userwallet);
            }

            _context.SaveChanges();
        }

        //public void Update(int id, UpdateRequest model)
        //{
            //var user = getUser(id);

            //// validate
            //if (model.Username != user.UserName && _context.Users.Any(x => x.UserName == model.Username))
            //    throw new AppException("Username '" + model.Username + "' is already taken");

            //// hash password if it was entered
            //if (!string.IsNullOrEmpty(model.Password))
            //    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            //// copy model to user and save
            //_mapper.Map(model, user);
            //_context.Users.Update(user);
            //_context.SaveChanges();
        //}

        public void Delete(int id)
        {
            var wallettxn = getWallet(id);
            _context.WalletTxns.Remove(wallettxn);
            _context.SaveChanges();
        }

        // helper methods
        // for query wallet transaction via id
        private WalletTxn getWallet(int id)
        {
            var wallettxn = _context.WalletTxns.Find(id);
            if (wallettxn == null) throw new KeyNotFoundException("Wallet Transaction not found");
            return wallettxn;
        }
        private UserWallet getUWallet(int id)
        {
            var userwallet = _context.UserWallet.Find(id);
            if (userwallet == null) throw new KeyNotFoundException("User Wallet not found");
            return userwallet;
        }
        private User getUsersViaToken(string TokenID)
        {
            var userwallet = _context.Users.Where(x=>x.TokenID == TokenID).FirstOrDefault();
            if (userwallet == null) throw new KeyNotFoundException("User not found");
            return userwallet;
        }
    }
}
