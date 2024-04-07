using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScreamSoundOO.src.utils
{
    public static class Crypto
    {

        public static string GerarMD5(string dado){

            MD5 md5Hasher = MD5.Create();

            byte[] dadoCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(dado));

            StringBuilder sb =  new StringBuilder();

            for (int i = 0; i < dadoCriptografado.Length; i++){
                sb.Append(dadoCriptografado[i].ToString("x2"));
            }

            return sb.ToString();
        }        
    }
}