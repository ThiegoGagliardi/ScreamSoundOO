using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using ScreamSoundOO.src.model;
using ScreamSoundOO.src.Interfaces;
using ScreamSoundOO.src.utils;
using ScreamSoundOO.src.DTO;

namespace ScreamSoundOO.src.db
{
    public class BandaADO
    {
        private IConnectionFactory _conn;

        public BandaADO(IConnectionFactory conn)
        {

            this._conn = conn;
        }

        public async Task<Banda> BuscaBandaPorNomeAsync(string nomeBanda)
        {

            string sql = "SELECT * FROM bandas WHERE nome = @nome";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());
            cmd.Parameters.AddWithValue("nome", nomeBanda);

            if (await _conn.AbrirConexaoAsync())
            {

                MySqlDataReader dr;

                Banda banda = new Banda();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {



                    while (await dr.ReadAsync())
                    {

                        banda.Id = Convert.ToInt32(dr["id"]);

                        banda.Nome = dr["nome"].ToString();

                        banda.Genero = (Genero)Convert.ToInt32(dr["genero"]);

                        banda.DataFundacao = Convert.ToDateTime(dr["fundacao"]);

                    }

                    _conn.FecharConexaoAsync();

                    return banda;
                }
            }

            return null;
        }

        public async Task<List<Banda>> BuscaBandaPorGeneroAsync(Genero genro)
        {

            string sql = "SELECT * FROM bandas WHERE genero = @genero";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());
            cmd.Parameters.AddWithValue("genero", (int)genro);

            if (await _conn.AbrirConexaoAsync())
            {

                MySqlDataReader dr;

                List<Banda> bandas = new List<Banda>();

                dr = cmd.ExecuteReader();

                while (await dr.ReadAsync())
                {

                    Banda banda = new Banda();

                    banda.Id = Convert.ToInt32(dr["id"]);

                    banda.Nome = dr["nome"].ToString();

                    banda.Genero = (Genero)Convert.ToInt32(dr["genero"]);

                    banda.DataFundacao = Convert.ToDateTime(dr["fundacao"]);

                    bandas.Add(banda);
                }

                _conn.FecharConexaoAsync();

                return bandas;
            }

            return null;
        }

        public async Task<bool> InserirBandaAsync(BandaDTO banda)
        {

            string sql = "INSERT INTO bandas (nome,genero,fundacao) VALUES(@nome, @genero, @fundacao)";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());
            cmd.Parameters.AddWithValue("nome", banda.Nome);
            cmd.Parameters.AddWithValue("genero", (int)banda.Genero);
            cmd.Parameters.AddWithValue("fundacao", banda.Fundacao);

            if (await _conn.AbrirConexaoAsync())
            {

                await cmd.ExecuteNonQueryAsync();
                await _conn.FecharConexaoAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Banda>> BuscaTodasBandasAsync()
        {

            string sql = "SELECT * FROM bandas";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());

            if (await _conn.AbrirConexaoAsync())
            {

                MySqlDataReader dr;

                List<Banda> bandas = new List<Banda>();

                dr = cmd.ExecuteReader();

                while (await dr.ReadAsync())
                {

                    Banda banda = new Banda();

                    banda.Id = Convert.ToInt32(dr["id"]);

                    banda.Nome = dr["nome"].ToString();

                    banda.Genero = (Genero)Convert.ToInt32(dr["genero"]);

                    banda.DataFundacao = Convert.ToDateTime(dr["fundacao"]);

                    bandas.Add(banda);
                }

                _conn.FecharConexaoAsync();

                return bandas;
            }

            return null;
        }
    }
}