using System.Security.Cryptography;
using System.Text;

namespace WEBAPI.Helpers
{
    
    public class EnCryptoNyt
    {
        public string CryptMyWord(string Password)
        {
            string OutputWord = string.Empty;

            try
            {
                using (var sha256 = SHA256.Create())
                {
                    // Send text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                    // Get the hashed string.  
                    OutputWord = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();                    
                }
            }
            catch (Exception)
            {

            }

            return OutputWord;
        }

    }
}
