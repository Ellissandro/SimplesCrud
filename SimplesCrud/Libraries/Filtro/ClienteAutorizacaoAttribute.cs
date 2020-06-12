using SimplesCrud.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimplesCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginUsuario _loginUsuario;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginUsuario = (LoginUsuario) context.HttpContext.RequestServices.GetService(typeof(LoginUsuario));
            Usuario cliente = _loginUsuario.GetUsuario();
            if (cliente == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado." };
            }

        }
    }
}
