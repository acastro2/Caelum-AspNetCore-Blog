using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private DAO.PostDAO Dao;

        public HomeController()
        {
            Dao = new DAO.PostDAO();
        }

        public IActionResult Index()
        {
            return View(Dao.ListaPublicados());
        }
    }
}