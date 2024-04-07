using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

using ScreamSoundOO.src.Interfaces;

namespace ScreamSoundOO.src.db
{
    public class ConnectionFactory : IConnectionFactory, IDisposable 
    {
        const string STRING_CONEXAO = "";
        
        private MySqlConnection _conn;

        public ConnectionFactory(){
           this._conn = new MySqlConnection(STRING_CONEXAO);
        }

        public MySqlConnection PegarConexao(){
            return _conn;
        }

        public async Task<bool> AbrirConexaoAsync(){
          try
            {
                await _conn.OpenAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir conexão: " + ex.Message);
                return false;
            }        
        }

        public async Task<bool> FecharConexaoAsync()
        {
            try
            {
                await _conn.CloseAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fechar conexão: " + ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _conn.Close();
            _conn.Dispose();            
        }
    }
}