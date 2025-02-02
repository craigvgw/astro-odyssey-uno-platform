﻿using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SpaceShooterGame
{
    public static class StringExtensions
    {
        private static readonly string encryptionKey1 = "ASDWU&*^%JHJOOI)()^&HJ*^*^&KLJ:KLHJH";
        private static readonly string encryptionKey2 = "IYUHKJ(*&(*%^*GKHJGJHRTU%*^(*&YHOUIH";

        /// <summary>
        /// Checks if the provided string is null or empty or white space.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrBlank(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static (bool IsValid, string Message) IsValidFullName(string fullName)
        {
            if (!Regex.IsMatch(fullName, @"^[\p{L}\p{M}' \.\-]+$"))
                return (false, "INVALID_CHARACTERS_IN_FULLNAME");

            return (true, "OK");
        }

        public static (bool IsStrong, string Message) IsStrongPassword(string passwd)
        {
            if (passwd.IsNullOrBlank())
                return (false, "LENGTH_MUST_BE_GREATER_THAN_8_CHARS");

            if (passwd.Length < 8)
                return (false, "LENGTH_MUST_BE_GREATER_THAN_8_CHARS");

            if (passwd.Length > 14)
                return (false, "LENGTH_MUST_BE_LESS_THAN_14_CHARS");

            if (!passwd.Any(char.IsUpper))
                return (false, "MUST_CONTAIN_ONE_UPPERCASE_CHAR");

            if (!passwd.Any(char.IsLower))
                return (false, "MUST_CONTAIN_ONE_LOWERCASE_CHAR");

            if (passwd.Contains(" "))
                return (false, "MUST_NOT_CONTAIN_SPACE");

            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();
            char[] passArray = passwd.ToCharArray();

            if (!passArray.Any(x => specialChArray.Contains(x)))
                return (false, "MUST_CONTAIN_ONE_SPECIAL_CHAR");

            return (true, "PASSWORD_IS_STRONG");
        }

        /// <summary>
        /// Get initials from a given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetInitials(string name)
        {
            string[] nameSplit = name.Split(new string[] { ",", ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            string initials = "";

            foreach (string item in nameSplit)
            {
                initials += item.Substring(0, 1).ToUpper();
            }

            return initials.ToUpperInvariant();
        }

        public static string Encrypt(this string plainText)
        {
            if (plainText.IsNullOrBlank())
            {
                return plainText;
            }

            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            plainText = Convert.ToBase64String(clearBytes);
            plainText = encryptionKey1 + plainText + encryptionKey2;

            return plainText;
        }

        public static string Decrypt(this string encodedData)
        {
            if (encodedData.IsNullOrBlank())
            {
                return encodedData;
            }

            encodedData = encodedData.Replace(encryptionKey1, "").Replace(encryptionKey2, "");
            byte[] cipherBytes = Convert.FromBase64String(encodedData);
            encodedData = Encoding.Unicode.GetString(cipherBytes);

            return encodedData;
        }       

        public static string UnBitShift(this string text)
        {
            int shft = 5;
            string decrypted = Encoding.UTF8.GetString(Convert.FromBase64String(text)).Select(ch => ch >> shft).Aggregate("", (current, val) => current + (char)(val / 2));
            return decrypted;
        }
    }
}
