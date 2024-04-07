using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScreamSoundOO.src.db;
using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.model; 
using ScreamSoundOO.src.Interfaces;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel;


namespace ScreamSoundOO.src.services
{
    public class NotaService
    {
        public async Task<bool> InserirNotaAsync(NotaDTO nota){

            IConnectionFactory conn = new ConnectionFactory();
            NotaADO notaADO = new NotaADO(conn);
            
            return await notaADO.InserirNotaAsync(nota);            
        }

        public async Task<List<NotasBandaDTO>> BuscarNotasUsuarioBandaAsync(Usuario usuario){

            IConnectionFactory conn = new ConnectionFactory();
            NotaADO notaADO = new NotaADO(conn);
            
            return  await notaADO.BuscarNotasClienteBandaAsync(usuario.Id);
        }

        public async Task<List<NotasBandaDTO>> BuscarNotasBandaAsync(Banda banda){

            IConnectionFactory conn = new ConnectionFactory();
            NotaADO notaADO = new NotaADO(conn);
            
            return await notaADO.BuscarNotasBandaAsync(banda.Id);
        }        
    }
}