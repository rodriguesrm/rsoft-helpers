using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RSoft.Helpers.Security
{

    /// <summary>
    /// Helpers to MD5 convertions
    /// </summary>
    public static class MD5
    {

        /// <summary>
        /// Generate hash from string expression
        /// </summary>
        /// <param name="input">Expression to convert</param>
        public static byte[] HashMD5(string input)
            => HashMD5(input, out _);

        /// <summary>
        /// Generate hash from string expression
        /// </summary>
        /// <param name="input">Expression to convert</param>
        /// <param name="result">Output variable result</param>
        public static byte[] HashMD5(string input, out string result)
        {

            byte[] data = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            result = sb.ToString().ToUpper();

            return data;

        }

        /// <summary>
        /// Convert hexadecimal expression to byte array
        /// </summary>
        /// <param name="hex">Hexadecimal string expression</param>
        public static byte[] StringToByteArray(string hex)
            => Enumerable
                .Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

        /// <summary>
        /// Convert byte array to hexadecimal string expression
        /// </summary>
        /// <param name="bytes">Byte array to convert</param>
        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

    }

}