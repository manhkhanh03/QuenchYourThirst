using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace QuenchYourThirst.Utilities
{
    public class Functions
    {
        public static long _Id = 0;
        public static string _LoginName = String.Empty;
        public static string _UserName = String.Empty;
        public static long _RoleId= 0;
        public static string _Email = String.Empty;
        public static string _Address = String.Empty;
        public static string _Phone = String.Empty;
		public static string _Image = String.Empty;
		public static string _Created_at = String.Empty;
        public static string _Message = String.Empty;
		public static string _ErrorMessage = String.Empty;

		public static string changeStringToString(string name)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(name);
        }
        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            for(int i = 0; i < 5; i ++)
            {
                str = MD5Hash(str + "-" + str);
            }
            return str;
        }

        public static bool isLogin ()
        {
            if (string.IsNullOrEmpty(Functions._LoginName) || string.IsNullOrEmpty(Functions._Email) || Functions._Id <= 0)
                return false;
            return true;
        }

        public static string getCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
