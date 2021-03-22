using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbertEinsteinTeste.Models.ViewModels
{
    public class ConsultaFormViewModel
    {
        [Key] 
        public int ConsultaFormViewModelId { get; set; }
        public Paciente Paciente { get; set; }
        public Consulta Consulta { get; set; }
        public Medico Medico { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
