using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<Models.Post>
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

            //ViewBag.Posts = lista;

            return View(lista);
        }
    }
}