using Blog.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Post")]
    [ValidateClass]
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(40)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Resumo é obrigatório")]
        public string Resumo { get; set; }
        [RequiredIf("Resumo", "", ErrorMessage = "Categoria Obrigatória quando resumo preenchido")]
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
    }
}
