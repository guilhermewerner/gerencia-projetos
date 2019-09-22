using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjetos.Models
{
    public class DesenvolvedorRequisito
    {
        public int DesenvolvedorId { get; set; }
        public Requisito Desenvolvedor { get; set; }
        
        public int RequisitoId { get; set; }
        public Requisito Requisito { get; set; }
        
        [DataType(DataType.Time)]
        public TimeSpan TempoGasto { get; set; }
    }
}
