using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private List<Models.Post> Lista;

        public PostController()
        {
            Lista = new List<Models.Post>
            {
                new Models.Post
                {
                    Titulo = "Harry Potter",
                    Resumo = "Bruxo",
                    Categoria = "Filme"
                },
                new Models.Post
                {
                    Titulo = "Interstellar",
                    Resumo = "Ficção",
                    Categoria = "Filme"
                },
                new Models.Post
                {
                    Titulo = "The Big Bang Theory",
                    Resumo = "Comédia Nerd",
                    Categoria = "Série"
                },
            };
        }

        public IActionResult Index()
        {
            return View(Lista);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Adiciona(Models.Post novo)
        {
            Lista.Add(novo);

            return View("Index", Lista);
        }
    }
}