using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.Interfaces;
using ScreamSoundOO.src.model;


namespace ScreamSoundOO.src.db
{
    public class UserADO
    {
        private IConnectionFactory _conn;

        public UserADO(IConnectionFactory conn)
        {
            this._conn = conn;
        }

        public async Task<bool> InserirAsync(UserDTO user)
        {

            string sql = "INSERT INTO usuarios (nome,senha) values (@nome, @senha)";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());

            cmd.Parameters.AddWithValue("nome", user.Nome);
            cmd.Parameters.AddWithValue("senha", user.Senha);

            if (await _conn.AbrirConexaoAsync())
            {

                cmd.ExecuteNonQuery();
                await _conn.FecharConexaoAsync();

                return true;
            }

            return false;
        }

        public async Task<Usuario> LocalizarUsarioAsync(UserDTO user)
        {
            string sql = "SELECT * FROM usuarios where nome = @nome and senha = @senha";

            MySqlCommand cmd = new MySqlCommand(sql, _conn.PegarConexao());

            cmd.Parameters.AddWithValue("nome", user.Nome);
            cmd.Parameters.AddWithValue("senha", user.Senha);

            if (await _conn.AbrirConexaoAsync())
            {

                MySqlDataReader dr;

                Usuario usuario = new Usuario();

                dr = cmd.ExecuteReader();

                if (!dr.HasRows){
                    return null;
                }

                while (await dr.ReadAsync())
                {

                    usuario.Id = Convert.ToInt32(dr["id"]);

                    usuario.Nome = dr["nome"].ToString();                    
                }

                _conn.FecharConexaoAsync();

                return usuario;

            }

            return null;
        }
    }
}

    