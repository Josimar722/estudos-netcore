
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaNet.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo dever conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Esse campo dever conter entre 3 e 60 caracteres")]

        public string Title { get; set; }
        


        
    }
}