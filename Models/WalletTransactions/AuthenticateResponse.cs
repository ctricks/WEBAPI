namespace WEBAPI.Models.WalletTransactions
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string WalletTransaction { get; set; }
        public double Amount { get; set; }
        public double Account_Balance { get; set; }                
    }
}
