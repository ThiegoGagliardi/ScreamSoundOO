using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreamSoundOO.src.model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Nome}";
        }

    }
}