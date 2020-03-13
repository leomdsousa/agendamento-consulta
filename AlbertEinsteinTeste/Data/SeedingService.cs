using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Models.Enums;

namespace AlbertEinsteinTeste.Data
{
    public class SeedingService
    {
        private readonly AlbertEinsteinTesteContext _context;

        public SeedingService(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Medico.Any() || _context.Paciente.Any() || _context.Consulta.Any())
            {
                return;
            }

            //CONSULTA SITUACAO
            ConsultaSituacao cs1 = new ConsultaSituacao("Finalizada");
            ConsultaSituacao cs2 = new ConsultaSituacao("Aberta");
            ConsultaSituacao cs3 = new ConsultaSituacao("Pendente");

            //MEDICO
            Medico m1 = new Medico("Leonardo Monteiro de Sousa", "M", new DateTime(1960, 2, 14), "Obstetra", 15000.0, false, "Rio de Janeiro", "RJ");
            Medico m2 = new Medico("Jailton Celestino de Sousa", "M", new DateTime(1971, 6, 21), "Neurologista", 35000.0, false, "São Paulo", "SP");
            Medico m3 = new Medico("Felipe Prior", "M", new DateTime(1990, 8, 8), "Dermatologista", 17000.0, false, "Pernambuco", "CE");
            Medico m4 = new Medico("Andre Barros", "M", new DateTime(1960, 2, 14), "Clínico Geral", 10000.0, false, "Curitiba", "PR");
            Medico m5 = new Medico("Miria Aparecida Monteiro", "F", new DateTime(1968, 5, 31), "Pediatra", 20000.0, false, "Itaquaquecetuba", "SP");
            Medico m6 = new Medico("Jacqueline Monteiro de Sousa", "F", new DateTime(1980, 05, 25), "Dermatologista", 17000.0, false, "Belo Horizonte", "MG");
            Medico m7 = new Medico("Maria de Lurdes Marinho Monteiro", "F", new DateTime(1950, 5, 31), "Anestesista", 20000.0, false, "Americana", "SP");
            Medico m8 = new Medico("Marcela McGowan", "F", new DateTime(1988, 1, 1), "Obstetra", 25000.0, false, "Salvador", "BA");

            //PACIENTE
            Paciente p1 = new Paciente("Hadassa Patrícia Alana Ribeiro", "F", new DateTime(1980, 1, 15), "Itaquaquecetuba", "SP");
            Paciente p2 = new Paciente("Marlene Lavínia Eliane Silveira", "F", new DateTime(1930, 12, 12), "Três Corações", "MG");
            Paciente p3 = new Paciente("Bryan Cláudio Peixoto", "M", new DateTime(2002, 11, 30), "Vitória", "ES");
            Paciente p4 = new Paciente("Bárbara Stefany Heloise", "F", new DateTime(2000, 4, 7), "São Paulo", "SP");
            Paciente p5 = new Paciente("Catarina Maya", "F", new DateTime(2005, 9, 4), "Cascavel", "PR");
            Paciente p6 = new Paciente("Pedro Henrique Cláudio Drumond", "M", new DateTime(1995, 10, 14), "Porto Alegre", "RS");
            Paciente p7 = new Paciente("Rafael André Severino Silveira", "M", new DateTime(1991, 12, 2), "Manaus", "AM");
            Paciente p8 = new Paciente("Andréia Magnato Ferreira", "F", new DateTime(1984, 4, 9), "São Paulo", "SP");

            //CONSULTA
            Consulta c5 = new Consulta("Vômito e dor de cabeça", "Gravidez", new DateTime(2020, 5, 1), m1, p1, (int)ConsultaSituacaoEnum.Pendente); //
            Consulta c1 = new Consulta("Dormê" +
                "ncia e formigamento", "Princípio de AVC", new DateTime(2019, 10, 15), m2, p2, (int)ConsultaSituacaoEnum.Finalizada);
            Consulta c6 = new Consulta("Coçeira e vermelhidão na pele", "Micose", new DateTime(2020, 3, 25), m3, p3, (int)ConsultaSituacaoEnum.Pendente);
            Consulta c2 = new Consulta("Dor de garganta, tosse", "Virose", new DateTime(2019, 10, 15), m4, p4, (int)ConsultaSituacaoEnum.Finalizada);
            Consulta c7 = new Consulta("Falta de concentração e dificuldade em ler", "Déficit de atenção", new DateTime(2020, 4, 19), m5, p5, (int)ConsultaSituacaoEnum.Pendente);
            Consulta c8 = new Consulta("Pele descascando no pé e mal odor", "Fungo", new DateTime(2020, 3, 30), m6, p6, (int)ConsultaSituacaoEnum.Pendente);
            Consulta c3 = new Consulta("Dores musculares, especialmente nas costas e pernas", "Virose", new DateTime(2019, 10, 31), m7, p7, (int)ConsultaSituacaoEnum.Finalizada);
            Consulta c4 = new Consulta("Vômito e dor de cabeça", "Gravidez", new DateTime(2019, 10, 15), m8, p8, (int)ConsultaSituacaoEnum.Finalizada);

            _context.ConsultaSituacao.AddRange(cs1, cs2, cs3);
            _context.Consulta.AddRange(c1, c2, c3, c4, c5, c6, c7, c8);
            _context.Paciente.AddRange(p1, p2, p3, p4, p5, p6, p7, p8);
            _context.Consulta.AddRange(c1, c2, c3, c4, c5, c6, c7, c8);
            _context.SaveChanges();
        }
    }
}
