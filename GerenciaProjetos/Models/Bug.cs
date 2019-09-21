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
        [Key, Column(Order = 1)]
        public int DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }

        [Key, Column(Order = 2)]
        public int RequisitoId { get; set; }
        public Requisito Requisito { get; set; }

        public string Prioridade { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public int CriadorId { get; set; }
        public Desenvolvedor Criador { get; set; }

        public bool FoiResolvido { get; set; }
    }
}
