using Blog.Models;
using System.Collections.Generic;
using Xunit;

namespace Blog.Test.Models
{
    public class CategoriaComQuantidadeViewModelTest
    {
        [Fact]
        public void IgnorarEspacos()
        {
            var filmeMulherMaravilha = new Post
            {
                Titulo = "Mulher Maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };

            var filmeSenhorAneis = new Post
            {
                Titulo = "Senhor dos Anéis",
                Resumo = "As duas torres",
                Categoria = " Filme "
            };

            var posts = new List<Post> { filmeMulherMaravilha, filmeSenhorAneis };

            var categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);

            int quantidadeDeFilmes = categoriaComQuantidade.GetQuantidadeDePostsDa("Filme");

            Assert.Equal(2, quantidadeDeFilmes);
        }
    }
}
