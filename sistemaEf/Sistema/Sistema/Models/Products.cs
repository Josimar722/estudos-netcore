using System;
using System.ComponentModel.DataAnnotations;


namespace sistemaNet.Models
{
    public class Product
    {

        [Key]

        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]

        public string Title { get; set; }


        [MaxLength(1024, ErrorMessage = "Este campo deve conter minimo 1024 caracteres")]

        public string Description { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço não pode ser igual a zero")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
