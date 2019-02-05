using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private DAO.PostDAO Dao;

        public PostController()
        {
           Dao = new DAO.PostDAO();
        }

        public IActionResult Index()
        {
            return View(Dao.Lista());
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Models.Post novo)
        {
            Dao.Insere(novo);

            return RedirectToAction("Index");
        }
    }
}