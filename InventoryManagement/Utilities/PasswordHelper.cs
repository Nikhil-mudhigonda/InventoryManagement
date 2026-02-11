using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InventoryManagement.Utilities
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder str = new StringBuilder();

                foreach(byte b in bytes)
                {
                    str.Append(b.ToString("x2"));
                }
                return str.ToString();
            }
        }
    }
}