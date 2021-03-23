using System;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoConsulta.Models
{
    public class Consulta
    {
        public Consulta()
        {
        }

        public Consulta(string sintoma, string diagnostico, DateTime dataConsulta, Medico medico, Paciente paciente, int consultaSituacao)
        {
            Sintoma = sintoma;
            Diagnostico = diagnostico;
            DataConsulta = dataConsulta;
            Medico = medico;
            Paciente = paciente;
            ConsultaSituacaoId = consultaSituacao;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} - Preenchimento obrigatório")]
        public string Sintoma { get; set; }
        [Required(ErrorMessage = "{0} - Preenchimento obrigatório")]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "{0} - Preenchimento obrigatório")]
        public DateTime DataConsulta { get; set; }
        [Required(ErrorMessage = "{0} - Preenchimento obrigatório")]
        [Display(Name = "Médico")]
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        [Required(ErrorMessage = "{0} - Preenchimento obrigatório")]
        [Display(Name = "Paciente")]
        public Paciente Paciente { get; set; }
        [Display(Name = "Paciente Id")]
        public int PacienteId { get; set; }
        [Display(Name = "Situação")]
        public ConsultaSituacao ConsultaSituacao { get; set; }
        [Display(Name = "Situação Id")]
        public int ConsultaSituacaoId { get; set; }
    }
}
