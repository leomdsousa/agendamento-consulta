using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Models
{
    public class Paciente
    {
        public Paciente()
        {
        }

        public Paciente(string nome, string sexo, DateTime dataNascimento, string cidade, string estado)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Cidade = cidade;
            Estado = estado;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
