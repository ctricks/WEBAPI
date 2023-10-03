using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Entities
{
    public class UserBetTxn
    {
        public int Id { get; set; }
            
        public double BetAmount { get; set; }   
        public DateTime BetDate { get; set; }

        public int BetColorId { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
