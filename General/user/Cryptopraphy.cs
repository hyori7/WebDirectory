using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace General
{
    public class Cryptopraphy
    {
        private static string password = "Tedspassword"; //komododragon

        public static String Password
        {
            set { password = value; }
        }

        public static String Encryption(string text)
        {
            return Cryption(text, password, true);
        }

        public static String Decryption(string text)
        {
            return Cryption(text, password, false);
        }

        public static String Cryption(string text, string password, bool boolCrypt)
        {
            byte[] utf8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

            PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(password, utf8_Salt);

            Rijndael i_Alg = Rijndael.Create();
            i_Alg.Key = i_Pass.GetBytes(32);
            i_Alg.IV = i_Pass.GetBytes(16);

            ICryptoTransform i_Trans = (boolCrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

            MemoryStream i_Mem = new MemoryStream();
            CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);

            byte[] utf8_Data;
            if (boolCrypt) utf8_Data = Encoding.Unicode.GetBytes(text);
            else utf8_Data = Convert.FromBase64String(text);

            try
            {
                i_Crypt.Write(utf8_Data, 0, utf8_Data.Length);
                i_Crypt.Close();
            }
            catch { return null; }

            if (boolCrypt) return Convert.ToBase64String(i_Mem.ToArray());
            else return Encoding.Unicode.GetString(i_Mem.ToArray());
        }
    }
}
