using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Jason.Common.Helper
{
    public class SaltHashHelper:ISaltHashHelper
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">The size of salt byte</param>
        /// <param name="str">The string to be hashed</param>
        /// <returns></returns>
        public HashSalt GenerateSaltedHash(int size, string str)
        {
            var saltBytes = new byte[size];
            //Create a strong random number to saltBytes
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DriveBytes = new Rfc2898DeriveBytes(str, saltBytes, 1000);
            var hashedStr = Convert.ToBase64String(rfc2898DriveBytes.GetBytes(256));

            HashSalt hashSaltedStr = new HashSalt { Hash = hashedStr, Salt = salt };
            return hashSaltedStr;
        }

        /// <summary>
        /// If a input string, e.g. a password is consistent with the hash and salt value
        /// return true
        /// Else return false.
        /// </summary>
        /// <param name="inputStr">The string to be verified, e.g. a password</param>
        /// <param name="storedHash">The hash value used to verify input</param>
        /// <param name="storedSalt">The salt value used to verify input</param>
        /// <returns></returns>
        public bool VerifyStr(string inputStr, HashSalt data)
        {
            var saltBytes = Convert.FromBase64String(data.Salt);
            var rfc2898DriveBytes = new Rfc2898DeriveBytes(inputStr, saltBytes, 1000);
            return Convert.ToBase64String(rfc2898DriveBytes.GetBytes(256)) == data.Hash;
        }

    }
}
