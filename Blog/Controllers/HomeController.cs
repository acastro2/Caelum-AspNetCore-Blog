using Blog.DAO;
using Blog.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext _context;
        private PostDAO _dao;

        public HomeController()
        {
            _context = new BlogContext();
            _dao = new PostDAO(_context);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}