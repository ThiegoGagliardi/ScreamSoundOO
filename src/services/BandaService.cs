using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.db;
using ScreamSoundOO.src.Interfaces;
using ScreamSoundOO.src.utils;
using ScreamSoundOO.src.model; 

namespace ScreamSoundOO.src.services
{
    public class BandaService
    {
        public async Task<Banda> BuscarBandaPorNomeAsync(string nomeBanda)
        {

            using (IConnectionFactory conn = new ConnectionFactory())
            {
                try
                {
                    BandaADO bandaAdo = new BandaADO(conn);

                    return await bandaAdo.BuscaBandaPorNomeAsync(nomeBanda);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao buscar banda: {ex.Message}");
                }
            }

            return null;
        }

        public async void InserirBandaAsync(BandaDTO banda)
        {

            using (IConnectionFactory conn = new ConnectionFactory())
            {
                try
                {
                    BandaADO bandaAdo = new BandaADO(conn);
                    
                    await bandaAdo.InserirBandaAsync(banda);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inserir banda: {ex.Message}");
                }
            }
        }

        public async Task<List<Banda>> BuscarBandaGeneroAsync(Genero genero)
        {

            IConnectionFactory conn = new ConnectionFactory();
            BandaADO bandaAdo = new BandaADO(conn);

            return await bandaAdo.BuscaBandaPorGeneroAsync(genero);
            
        }

       public async Task<List<Banda>> BuscarTodasBandasAsync()
        {

            IConnectionFactory conn = new ConnectionFactory();
            BandaADO bandaAdo = new BandaADO(conn);

            return await bandaAdo.BuscaTodasBandasAsync();            
        }      
    }
}