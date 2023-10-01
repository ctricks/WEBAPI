using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Entities
{
    public class FightMatch
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int MatchNumber { get; set; }

        //CB-10022023 Reference for User Bet
        public virtual ICollection<UserBetTxn> UBetTxn { get; set; }

        //CB-10022023 Reference for Bet Odd
        public virtual ICollection<BetOdd> UBetOdd { get; set; }

        [Column("create_ts")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
