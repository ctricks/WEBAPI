using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Entities
{
    public class UserWallet
    {
        public int Id { get; set; }
        public int? user_id { get; set; }
        public double? available_balance { get; set; }
        public double? total_balance { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("update_ts")]
        public DateTime UpdateDate { get; set; }
    }
}
