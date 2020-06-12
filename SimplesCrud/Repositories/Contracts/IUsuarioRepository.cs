using SimplesCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesCrud.Repositories.Contracts
{
   public interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);
        void Cadastrar(Usuario usuario);     
    }
}
