using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScreamSoundOO.src.utils;

namespace ScreamSoundOO.src.DTO
{
    public class BandaDTO
    {        
        public string Nome { get; set; }

        public Genero Genero { get; set; }

        public DateTime Fundacao { get; set; }
   
    }
}