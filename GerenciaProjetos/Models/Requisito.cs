using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class Requisito
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Descricao { get; set; }

        [MaxLength(100)]
        public string Observacoes { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }

        public bool EFuncional { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }

        public IEnumerable<Bug> Bugs { get; set; }
    }
}
