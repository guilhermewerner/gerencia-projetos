using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class DesenvolvedorProjeto
    {
        public int DesenvolvedorId { get; set; }
        public Requisito Desenvolvedor { get; set; }
        
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
