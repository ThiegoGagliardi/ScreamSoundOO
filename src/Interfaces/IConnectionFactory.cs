using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScreamSoundOO.src.Interfaces
{
    public interface IConnectionFactory : IDisposable
    {
        MySqlConnection PegarConexao();

         Task<bool> AbrirConexaoAsync();

         Task<bool> FecharConexaoAsync();        
    }
}