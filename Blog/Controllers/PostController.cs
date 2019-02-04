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
                    Titulo = "Harry Potter",
                    Resumo = "Bruxo",
                    Categoria = "Filme"
                },
                new Models.Post
                {
                    Titulo = "Harry Potter",
                    Resumo = "Bruxo",
                    Categoria = "Filme"
                },
            };

            ViewBag.Posts = lista;

            return View();
        }
    }
}