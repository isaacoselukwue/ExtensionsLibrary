using System.Security.Cryptography;
using System.Text;

namespace ExtensionsLibrary
{
    public class Random
    {
        public static string RandomToken()
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
            using (var crypto = RandomNumberGenerator.Create())
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
        //numbers
        public static string GetAnyAmountOfToken(int number)
        {
            string authToken = GetUniqueKey(number);
            return authToken;
        }
        private static string GetUniqueAlphaNumericKeys(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
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
        public static string GetAnyAmountOfTokensAlphaNumeric(int number)
        {
            string authToken = GetUniqueAlphaNumericKeys(number);
            return authToken;
        }
    }
    
}