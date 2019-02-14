using Blog.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ViewComponents
{
    public class ListaCategoriasViewComponent : ViewComponent
    {
        private readonly PostDAO _dao;

        public ListaCategoriasViewComponent(PostDAO dao)
        {
            _dao = dao;
        }

        public IViewComponentResult Invoke()
        {
            var posts = _dao.ListaPublicados();
            var categoriaQuantidade = new Models.CategoriaComQuantidadeViewModel(posts);

            return View(categoriaQuantidade);
        }
    }
}
