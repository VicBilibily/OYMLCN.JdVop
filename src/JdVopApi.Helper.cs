using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {

        static byte[] UnHex(string hex)
        {
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            // 需要将 hex 转换成 byte 数组。
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                catch
                {
                    // 转换失败直接报错
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            return bytes;
        }
        /// <summary>
        ///   京东DES加密内容解密
        /// </summary>
        public static string DesDecrypt(string decryptString, string decryptKey)
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
            byte[] rgbIV = rgbKey;
            byte[] inputByteArray = UnHex(decryptString);
            using DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            dCSP.Mode = CipherMode.CBC;
            dCSP.Padding = PaddingMode.PKCS7;
            using MemoryStream mStream = new MemoryStream();
            using CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
