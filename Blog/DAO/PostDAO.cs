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

        public void Insere(Models.Post post)
        {
            using (var context = new Infra.BlogContext())
            {
                context.Posts.Add(post);

                context.SaveChanges();
            }
        }
    }
}
