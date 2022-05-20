using System.Security.Cryptography;
using System.Text;

namespace ExtensionsLibrary
{
    public class RandomAlphaNumericGenerator
    {
        /// <summary>
        /// This method returns a cryptographic 6-digit pseudo-random number for token validation.
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            //var CharCombination = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*_+~,./?|";
            //var random = new Random();
            //var resultToken = new string(Enumerable.Repeat(CharCombination,500).Select(t => t[random.Next(t.Length)]).ToArray());
            //updated for cryptographic strength and unbiased randomness
            string authToken = GetUniqueKey(6);
            return authToken;
        }
        internal static readonly char[] chars =
            "1234567890".ToCharArray();
        internal static readonly char[] chars2 ="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
        /// <summary>
        /// This returns any length of number of cryptographically pseudo-random digits.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetToken(int number)
        {
            string authToken = GetUniqueKey(number);
            return authToken;
        }
        private static string GetUniqueAlphaNumericKeys(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars2.Length;

                result.Append(chars2[idx]);
            }

            return result.ToString();
        }
        /// <summary>
        /// This returns any number of cryptographically pseudo-random alphanumeric characters.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetAnyAmountOfTokensAlphaNumeric(int number)
        {
            string authToken = GetUniqueAlphaNumericKeys(number);
            return authToken;
        }
    }
    
}