using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Models.Post> Lista()
        {
            using (var context = new Infra.BlogContext())
            {
                return context.Posts.ToList();
            }
        }

        public IList<Models.Post> FiltraPorCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
            {
                return Lista();
            }

            using (var context = new Infra.BlogContext())
            {
                return context.Posts.Where(p => p.Categoria.Contains(categoria, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
        }

        public void Insere(Models.Post post)
        {
            using (var context = new Infra.BlogContext())
            {
                context.Posts.Add(post);

                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var context = new Infra.BlogContext())
            {
                var post = context.Posts.Find(id);

                if (post == null)
                {
                    return;
                }

                context.Posts.Remove(post);

                context.SaveChanges();
            }
        }

        public Models.Post BuscaPorId(int id)
        {
            using (var context = new Infra.BlogContext())
            {
                return context.Posts.Find(id);
            }
        }

        public void Atualiza(Models.Post post)
        {
            using (var context = new Infra.BlogContext())
            {
                context.Entry(post).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
