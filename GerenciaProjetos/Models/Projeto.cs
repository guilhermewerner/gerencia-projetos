using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Solicitante { get; set; }
        
        public IEnumerable<Requisito> Requisitos { get; set; }
    }
}
