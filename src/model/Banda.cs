using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScreamSoundOO.src.utils;

namespace ScreamSoundOO.src.model
{
    public class Banda
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public Genero Genero { get; set; }

        public DateTime DataFundacao { get; set; }

        public DateTime DataEncerramento { get; set;}

        public override string ToString(){
            return this.Nome;
        }

    }
}