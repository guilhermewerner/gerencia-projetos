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
        public int DesenvolvedorId { get; set; }
        public Requisito Desenvolvedor { get; set; }
        
        public int RequisitoId { get; set; }
        public Requisito Requisito { get; set; }
        
        public string Prioridade { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public int CriadorId { get; set; }
        public Requisito Criador { get; set; }

        public bool FoiResolvido { get; set; }
    }
}
