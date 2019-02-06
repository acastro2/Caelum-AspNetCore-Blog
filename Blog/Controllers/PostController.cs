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

        public IActionResult RemovePost(int id)
        {
            Dao.Remove(id);

            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            return View(Dao.BuscaPorId(id));
        }

        [HttpPost]
        public IActionResult EditaPost(Models.Post novo)
        {
            Dao.Atualiza(novo);

            return RedirectToAction("Index");
        }
    }
}