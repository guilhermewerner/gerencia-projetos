using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Esse valor não é permitido.")]
        public string Nome { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [RegularExpression(@"^([a-z0-9_\.\+-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$", ErrorMessage = "Por favor insira um endereço de e-mail válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(45, MinimumLength = 8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Compare("Senha", ErrorMessage = "As senhas não combinam.")]
        public string ConfirmarSenha { get; set; }

        public bool EAdmin { get; set; }
    }
}
