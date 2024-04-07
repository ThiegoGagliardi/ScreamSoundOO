using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScreamSoundOO.src.db;
using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.model;
using ScreamSoundOO.src.Interfaces;

namespace ScreamSoundOO.src.services
{
    public class UserService
    {
        public async void InserirUsuarioAsync(UserDTO usuario){

            using (IConnectionFactory conn = new ConnectionFactory()){

                try
                {
                    UserADO userAdo = new UserADO(conn);
                    
                    await userAdo.InserirAsync(usuario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inserir banda: {ex.Message}");
                }
            }
        }

        public async Task<Usuario> BuscarUsuarioAsync(UserDTO usuario){

            using (IConnectionFactory conn = new ConnectionFactory()){

                try
                {
                    UserADO userAdo = new UserADO(conn);
                    
                    return await userAdo.LocalizarUsarioAsync(usuario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inserir banda: {ex.Message}");
                }
            }

            return null;
        }
    }
}