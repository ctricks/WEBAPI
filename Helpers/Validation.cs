using Microsoft.EntityFrameworkCore;
using WEBAPI.Entities;

namespace WEBAPI.Helpers
{
    public interface IValidation
    {
        User getUserById(int id);
        User getUser(string TokenId);
        UserAdmin getUserAdminById(int id);
        UserAdmin getUserAdmin(string TokenId);
    }

        
    public class Validation : IValidation
    {
        private readonly DataContext _dbcontext;

        public User getUserById(int Id)
        {
            var user = _dbcontext.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public User getUser(string TokenId)
        {
            var user = _dbcontext.Users.Where(x => x.TokenID == TokenId).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        public UserAdmin getUserAdminById(int Id)
        {
            var user = _dbcontext.UserAdmins.Where(x => x.Id == Id).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User Not Found. Please use Admin Account.");
            return user;
        }
        public UserAdmin getUserAdmin(string TokenId)
        {
            var user = _dbcontext.UserAdmins.Where(x => x.TokenID == TokenId).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("Please use Admin Account.");
            return user;
        }
    }
}
