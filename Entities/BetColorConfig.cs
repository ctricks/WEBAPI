using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Entities
{
    public class BetColorConfig
    {
        public int Id { get; set; }
        public string ColorName { get; set; }

        //CB-10022023 Reference for User Bet
        public virtual ICollection<UserBetTxn> UBetTxn { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
