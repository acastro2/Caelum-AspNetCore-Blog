using Blog.Models;
using System.ComponentModel.DataAnnotations;

namespace Blog.ValidationAttributes
{
    public class ValidateClassAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var post = (Post)value;

            //if (!string.IsNullOrWhiteSpace(post.Titulo) && !string.IsNullOrWhiteSpace(post.Categoria))
            //{
            //    return new ValidationResult("Titulo e Categoria não podem estar preenchidos", new[] { "Titulo", "Categoria" });
            //}

            return ValidationResult.Success;
        }
    }
}
