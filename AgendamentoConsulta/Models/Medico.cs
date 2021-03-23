using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsulta.Models
{
    public class Medico
    {
        public Medico()
        {
        }

        public Medico(string nome, string sexo, DateTime dataNascimento, string especialidade, double salario, bool ferias, string cidade, string estado)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Especialidade = especialidade;
            Salario = salario;
            Ferias = ferias;
            Cidade = cidade;
            Estado = estado;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Especialidade { get; set; }
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double Salario { get; set; }
        [Display(Name = "Férias")]
        public bool Ferias { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [NotMapped]
        private string MedicoEspecialidade { get; set; }
        public string GetMedicoEspecialidade 
        {
            get { return Especialidade + " - " + Nome; }
        }
    }
}
