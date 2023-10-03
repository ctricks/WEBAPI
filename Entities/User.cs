using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEBAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; } 
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        public string? TokenID { get; set; }

        //For reference UserWallet Table
        public virtual ICollection<UserWallet> UWallet { get; set; }
        
        [JsonIgnore]
        public string? PasswordHash { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("update_ts")]
        public DateTime UpdateDate { get; set; }
    }
}
