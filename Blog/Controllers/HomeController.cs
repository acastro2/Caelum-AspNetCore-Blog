using Blog.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostDAO _dao;

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

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            return View("Index", _dao.FiltraPorCategoria(categoria));
        }
    }
}