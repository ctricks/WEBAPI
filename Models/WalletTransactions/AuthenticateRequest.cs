using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Models.WalletTransactions
{
    public class AuthenticateRequest
    {
        [Required]
        public string TokenID { get; set; }
        
        [Required]
        public string WalletTransaction { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double account_balance { get; set; }


    }
}
