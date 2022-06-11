using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ApiProdutos.Infra.Data.Utils
{
    public static class MD5Util
    {
        public static string Get(string value)
        {
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;
            foreach (var item in hash)
                result += item.ToString("X2"); //X2 -> hexadecimal

            return result;
        }
    }
}



