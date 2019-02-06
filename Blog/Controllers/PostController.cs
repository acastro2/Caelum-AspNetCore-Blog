using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            return View("Index", Dao.FiltraPorCategoria(categoria));
        }
    }
}