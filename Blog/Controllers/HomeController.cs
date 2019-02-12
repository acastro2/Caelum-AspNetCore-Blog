using Blog.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO _dao;

        public HomeController(PostDAO dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            return View(_dao.ListaPublicados());
        }

        public IActionResult BuscaPeloTermo(string termo)
        {
            ViewBag.Termo = termo;

            return View("Index", _dao.BuscaPeloTermo(termo));
        }
    }
}