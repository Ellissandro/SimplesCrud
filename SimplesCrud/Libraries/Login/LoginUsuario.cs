using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplesCrud.Libraries.Sessao;
using Newtonsoft.Json;
using SimplesCrud.Models;

namespace SimplesCrud.Libraries.Login
{
    public class LoginUsuario
    {
        private string Key = "Login.Usuario";
        private Sessao.Sessao _sessao;
        public LoginUsuario(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Usuario usuario)
        {
            string clienteJSONString = JsonConvert.SerializeObject(usuario);
            _sessao.Cadastrar(Key, clienteJSONString);
        }

        public Usuario GetUsuario()
        {
            if (_sessao.Existe(Key))
            {
                string clienteJSONString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Usuario>(clienteJSONString);
            }
            else
            {
                return null;
            }              
         }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
