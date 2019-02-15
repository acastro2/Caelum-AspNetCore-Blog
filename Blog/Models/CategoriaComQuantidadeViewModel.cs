using System.Collections.Generic;
using System.Linq;

namespace Blog.Models
{
    public class CategoriaComQuantidadeViewModel
    {
        private readonly Dictionary<string, int> categoriaPorQuantidade;

        public CategoriaComQuantidadeViewModel(IList<Post> posts)
        {
            categoriaPorQuantidade = new Dictionary<string, int>();

            posts.GroupBy(p => p.Categoria.Trim()).ToList()
                 .ForEach(o => categoriaPorQuantidade.Add(o.First().Categoria, o.Count()));
        }

        public IList<string> GetCategorias()
        {
            return categoriaPorQuantidade.Keys.ToList();
        }

        public int GetQuantidadeDePostsDa(string categoria)
        {
            return categoriaPorQuantidade[categoria];
        }
    }
}
