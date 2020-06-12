using SimplesCrud.Database;
using SimplesCrud.Models;
using SimplesCrud.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesCrud.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private SimplesCrudContext _banco;

        public UsuarioRepository(SimplesCrudContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(Usuario usuario)
        {
            _banco.Add(usuario);
            _banco.SaveChanges();
        }

        public Usuario Login(string Email, string Senha)
        {
            Usuario usuario = _banco.Usuarios.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return usuario;
        }
    }
}
