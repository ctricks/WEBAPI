using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEBAPI.Entities
{
    public class UserAdmin
    {
        public int Id { get; set; }
        public string? UserName { get; set; }         
        public string? Role { get; set; }
        public string? TokenID { get; set; }
        
        [JsonIgnore]
        public string? PasswordHash { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("update_ts")]
        public DateTime UpdateDate { get; set; }
    }
}
