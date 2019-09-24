using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }

        public int DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
    
        public int RequisitoId { get; set; }
        public Requisito Requisito { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Descricao { get; set; }

        [MaxLength(25)]
        public string Prioridade { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public bool FoiResolvido { get; set; }
    }
}
