namespace WEBAPI.Entities
{
    public class BetOdd
    {
        public int Id { get; set; }

        //CB-10022023 Reference for BetColorConfig 1 to Many
        public virtual ICollection<BetColorConfig>BetColor { get; set; }    
        public double OddValue { get; set; }

        //CB-10022023 Reference for User Bet
        public virtual ICollection<UserBetTxn> UBetTxn { get; set; }
    }
}
