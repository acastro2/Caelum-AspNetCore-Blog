using Blog.Infra;
using Blog.Models;
using System;
using System.Linq;

namespace Blog.DAO
{
    public class UsuarioDAO
    {
        private BlogContext _context;

        public UsuarioDAO(BlogContext context)
        {
            _context = context;
        }

        public Usuario Busca(string login, string senha)
        {
            return _context.Usuarios.Where(u => u.Nome.Equals(login, StringComparison.CurrentCultureIgnoreCase) &&
                                                u.Senha.Equals(senha, StringComparison.CurrentCultureIgnoreCase))
                                    .FirstOrDefault();
        }
    }
}
