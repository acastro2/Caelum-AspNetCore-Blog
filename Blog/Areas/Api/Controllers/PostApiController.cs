using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Api.Controllers
{
    [Area("Api")]
    [ApiController]
    [Route("/api/post")]
    public class PostApiController : ControllerBase
    {
        private readonly PostDAO _dao;

        public PostApiController(PostDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult BuscaTodosPosts()
        {
            return Ok(_dao.Lista());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscaPostPorId(int id)
        {
            return Ok(_dao.BuscaPorId(id));
        }

        [HttpPost]
        [Route("novo")]
        public IActionResult CadastraPost([FromBody]Post post)
        {
            _dao.Insere(post, null);
            return CreatedAtAction("BuscaPostPorId", new { id = post.Id }, post);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaPost(int id, [FromBody]Post post)
        {
            var postdb = _dao.BuscaPorId(id);

            if(postdb == null)
            {
                return NotFound();
            }

            postdb.Titulo = post.Titulo;
            postdb.Resumo = post.Resumo;
            postdb.Categoria = post.Categoria;
            postdb.Publicado = post.Publicado;
            postdb.DataPublicacao = post.DataPublicacao;

            _dao.Atualiza(postdb);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePost(int id)
        {
            var postdb = _dao.BuscaPorId(id);

            if (postdb == null)
            {
                return NotFound();
            }

            _dao.Remove(id);

            return NoContent();
        }
    }
}