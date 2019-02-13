using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext _context;

        public PostDAO(BlogContext context)
        {
            _context = context;
        }

        public IList<Post> Lista()
        {
            return _context.Posts.ToList();
        }

        public IEnumerable<Post> ListaPublicados()
        {
            return _context.Posts.Where(p => p.Publicado)
                                .OrderByDescending(p => p.DataPublicacao)
                                .ToList();
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
            {
                return Lista();
            }

            return _context.Posts.Where(p => p.Categoria.Contains(categoria, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public IList<Post> BuscaPeloTermo(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Lista();
            }

            return _context.Posts.Where(p => p.Publicado && (p.Categoria.Contains(termo, StringComparison.CurrentCultureIgnoreCase) || p.Titulo.Contains(termo, StringComparison.CurrentCultureIgnoreCase))).ToList();
        }

        public void Insere(Post post, Usuario autor)
        {
            _context.Usuarios.Attach(autor);
            post.Autor = autor;

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
            {
                return;
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public Post BuscaPorId(int id)
        {
            return _context.Posts.Find(id);
        }

        public void Atualiza(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Publica(int id)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
            {
                return;
            }

            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;

            _context.Entry(post).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Lista().Select(p => p.Categoria).Distinct().ToList();
            }

            return _context.Posts.Where(p => p.Categoria.Contains(termo, StringComparison.CurrentCultureIgnoreCase))
                .Select(p => p.Categoria).Distinct().ToList();
        }
    }
}