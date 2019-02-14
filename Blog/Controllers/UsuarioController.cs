using Blog.DAO;
using Blog.Extensions;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _dao;

        public UsuarioController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _dao.Busca(model.Login, model.Senha);

                if (usuario != null)
                {
                    HttpContext.Session.Set("usuario", usuario);
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }

            return View("Login", model);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastra(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = model.LoginName,
                    Email = model.Email,
                    Senha = model.Senha
                };

                _dao.Adiciona(usuario);

                return RedirectToAction("Login");
            }

            return View("Novo", model);
        }
    }
}