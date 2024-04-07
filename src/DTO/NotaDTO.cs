using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreamSoundOO.src.DTO
{
    public class NotaDTO
    {
        public NotaDTO(int idUsuario, int idBanda, int nota)
        {
            this.IdUsuario = idUsuario;
            this.IdBanda   = idBanda;
            this.Nota      = nota;
        }

        public int IdUsuario { get; set; }

        public int IdBanda { get; set; }

        public int Nota { get; set; }
    }
}