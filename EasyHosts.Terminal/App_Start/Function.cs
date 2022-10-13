using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EasyHosts.Terminal.App_Start
{
    public class Function
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nameHash"></param>
        /// <returns></returns>
        public static string HashText(string text, string nameHash)
        {
            HashAlgorithm algoritmo = HashAlgorithm.Create(nameHash);
            if (algoritmo == null)
            {
                throw new ArgumentException("Nome de hash incorreto", "nameHash");
            }
            byte[] hash = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hash);
        }
    }
}