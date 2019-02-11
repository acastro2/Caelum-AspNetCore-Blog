using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<Models.Post> ListaPublicados()
        {
            using (var context = new Infra.BlogContext())
            {
                return context.Posts.Where(p => p.Publicado)
                                    .OrderByDescending(p => p.DataPublicacao)
                                    .ToList();
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
                return context.Posts.Where(p => p.Categoria.Contains(categoria, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
        }

        public IList<Models.Post> BuscaPeloTermo(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Lista();
            }

            using (var context = new Infra.BlogContext())
            {
                return context.Posts.Where(p => p.Publicado && (p.Categoria.Contains(termo, StringComparison.CurrentCultureIgnoreCase) || p.Titulo.Contains(termo, StringComparison.CurrentCultureIgnoreCase))).ToList();
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

        public void Publica(int id)
        {
            using (var context = new Infra.BlogContext())
            {
                var post = context.Posts.Find(id);

                if (post == null)
                {
                    return;
                }

                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;

                context.Entry(post).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Lista().Select(p => p.Categoria).Distinct().ToList();
            }

            using (var context = new Infra.BlogContext())
            {
                return context.Posts.Where(p => p.Categoria.Contains(termo, StringComparison.CurrentCultureIgnoreCase))
                    .Select(p => p.Categoria).Distinct().ToList();
            }
        }
    }
}
