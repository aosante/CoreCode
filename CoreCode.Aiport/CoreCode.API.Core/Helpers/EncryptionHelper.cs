using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly MD5CryptoServiceProvider Md5CryptService = new MD5CryptoServiceProvider();
        
        public static string GetEncryptedMd5Value(string toEncryptParam)
        {
            StringBuilder strBuilder = new StringBuilder();  
            Md5CryptService.ComputeHash(Encoding.ASCII.GetBytes(toEncryptParam));  
            byte[] hashResult = Md5CryptService.Hash;
            foreach (var stringItem in hashResult)
            {
                strBuilder.Append(stringItem.ToString("x2")); //Format to UpperCase HexaDecimal Characters.
            }
            return strBuilder.ToString();  
        }
    }
}
