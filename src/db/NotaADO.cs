using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScreamSoundOO.src.Interfaces;
using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.model;
using MySql.Data.MySqlClient;

namespace ScreamSoundOO.src.db
{
    public class NotaADO
    {

        private IConnectionFactory _connFactory;

        public NotaADO(IConnectionFactory connFactor)
        {
            this._connFactory = connFactor;
        }

        public async Task<bool> InserirNotaAsync(NotaDTO nota)
        {

            string sql = "INSERT INTO notas (id_usuario,id_banda,nota) VALUES (@id_usuario, @id_banda, @nota)";

            MySqlCommand cmd = new MySqlCommand(sql, _connFactory.PegarConexao());

            cmd.Parameters.AddWithValue("id_usuario", nota.IdUsuario);
            cmd.Parameters.AddWithValue("id_banda", nota.IdBanda);
            cmd.Parameters.AddWithValue("nota", nota.Nota);

            if (await _connFactory.AbrirConexaoAsync())
            {

                await cmd.ExecuteNonQueryAsync();
                await _connFactory.FecharConexaoAsync();
                return true;
            }

            return false;
        }

        public async Task<List<NotasBandaDTO>> BuscarNotasClienteBandaAsync(int id_usuario)
        {

            string sql = "SELECT b.nome, n.nota FROM bandas b, notas n WHERE id_usuario = @id_usuario and n.id_banda = b.id";

            MySqlCommand cmd = new MySqlCommand(sql, _connFactory.PegarConexao());
            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

            List<NotasBandaDTO> notascliente = new List<NotasBandaDTO>();

            if (await _connFactory.AbrirConexaoAsync())
            {

                MySqlDataReader dr = cmd.ExecuteReader();

                while (await dr.ReadAsync())
                {

                    NotasBandaDTO notacliente = new NotasBandaDTO();

                    notacliente.Nota = Convert.ToInt32(dr["nota"]);
                    notacliente.NomeBanda = dr["nome"].ToString();

                    notascliente.Add(notacliente);
                }
            }

            return notascliente;
        }

        public async Task<List<NotasBandaDTO>> BuscarNotasBandaAsync(int id_banda)
        {

            string sql = "SELECT b.nome, n.nota  FROM notas n, bandas b WHERE id_banda = id and id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, _connFactory.PegarConexao());
            cmd.Parameters.AddWithValue("@id", id_banda);

            List<NotasBandaDTO> notasBandas = new List<NotasBandaDTO>();

            if (await _connFactory.AbrirConexaoAsync())
            {

                MySqlDataReader dr = cmd.ExecuteReader();

                while (await dr.ReadAsync())
                {

                    NotasBandaDTO nota = new NotasBandaDTO();

                    nota.Nota = Convert.ToInt32(dr["nota"]);
                    nota.NomeBanda = dr["nome"].ToString();

                    notasBandas.Add(nota);
                }
            }

            return notasBandas;
        }
    }
}
