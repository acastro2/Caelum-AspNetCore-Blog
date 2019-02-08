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
            return View(new Models.Post());
        }

        [HttpPost]
        public IActionResult Adiciona(Models.Post novo)
        {
            if (ModelState.IsValid)
            {
                Dao.Insere(novo);

                return RedirectToAction("Index");
            }

            return View("Novo", novo);
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
        public IActionResult EditaPost(Models.Post post)
        {
            if (ModelState.IsValid)
            {
                Dao.Atualiza(post);

                return RedirectToAction("Index");
            }

            return View("Visualiza", post);
        }

        public IActionResult PublicaPost(int id)
        {
            Dao.Publica(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = Dao.ListaCategoriasQueContemTermo(termoDigitado);

            return Json(model);
        }
    }
}