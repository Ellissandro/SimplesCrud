using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Filtro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplesCrud.Libraries.Login;
using SimplesCrud.Models;
using SimplesCrud.Repositories.Contracts;

namespace SimplesCrud.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioRepository _repositoryUsuario;
        private LoginUsuario _loginUsuario;

        public HomeController(IUsuarioRepository repositoryUsuario, LoginUsuario loginUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
            _loginUsuario = loginUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] Usuario usuario)
        {

            Usuario clienteDB = _repositoryUsuario.Login(usuario.Email, usuario.Senha);

            if (clienteDB != null)
            {
                _loginUsuario.Login(clienteDB);
                return RedirectToAction(nameof(Painel));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique o e-mail e senha digitado!";

                return View();
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _repositoryUsuario.Cadastrar(usuario);
                TempData["MSG_S"] = "Cadastro Realizado com sucesso!";

                return RedirectToAction(nameof(Cadastro));
            }
            return View();

        }

        [HttpGet]
        [ClienteAutorizacaoAttribute]
        public IActionResult Painel()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _loginUsuario.Logout();
            return RedirectToAction(nameof(Index));
        }
    }
}