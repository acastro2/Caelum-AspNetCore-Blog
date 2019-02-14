using Blog.DAO;
using Blog.Extensions;
using Blog.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private PostDAO _dao;

        public PostController(PostDAO dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            return View(_dao.Lista());
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
                var usuario = HttpContext.Session.Get<Models.Usuario>("usuario");

                _dao.Insere(novo, usuario);

                return RedirectToAction("Index");
            }

            return View("Novo", novo);
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            return View("Index", _dao.FiltraPorCategoria(categoria));
        }

        public IActionResult RemovePost(int id)
        {
            _dao.Remove(id);

            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            return View(_dao.BuscaPorId(id));
        }

        [HttpPost]
        public IActionResult EditaPost(Models.Post post)
        {
            if (ModelState.IsValid)
            {
                _dao.Atualiza(post);

                return RedirectToAction("Index");
            }

            return View("Visualiza", post);
        }

        public IActionResult PublicaPost(int id)
        {
            _dao.Publica(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = _dao.ListaCategoriasQueContemTermo(termoDigitado);

            return Json(model);
        }
    }
}