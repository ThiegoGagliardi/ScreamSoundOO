using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using ScreamSoundOO.src.utils;

namespace ScreamSoundOO.src.DTO
{
    public class UserDTO
    {
        public string Nome { get; set; }

        private string _senha;

        public string Senha { 
            get {return _senha;} 
            set { _senha = Crypto.GerarMD5(value);}
        }

    }
}