using AgendamentoConsulta.Models;
using AgendamentoConsulta.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlbertEinsteinTesteTests.Services
{
    public class ConsultaTests
    {
        private readonly ConsultaService _consultaService;
        private readonly AlbertEinsteinTesteMock _mock;

        public ConsultaTests()
        {
            _mock = new AlbertEinsteinTesteMock();
            _consultaService = new ConsultaService(_mock.ConsultaRepository.Object);
        }

        [Fact]
        public async void Verifica_Duplicidade_Consulta_Por_Medico_e_Horario()
        {
            //arrange
            Consulta consulta = new Consulta()
            {
                Id = 1,
                Medico = new Medico()
                {
                    Id = 1
                }
            };

            _mock.ConsultaRepository.Setup(x => x.FiltraConsultasPorMedicoByIdAsync(consulta.Medico.Id)).Returns(Task.FromResult(this.ObterConsultas()));

            //act
            var result = await _consultaService.VerificaDuplicidadeDeConsultaPorMedicoeHorario(consulta);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task Obter_Consulta_By_Id()
        {
            //arrange
            int id = 1;

            _mock.ConsultaRepository.Setup(x => x.ObterConsultaByIdAsync(id)).Returns(Task.FromResult(this.ObterConsulta()));

            //act
            var result = await _consultaService.ObterConsultaByIdAsync(id);

            //assert
            Assert.NotNull(result);
        }

        public Consulta ObterConsulta()
        {
            return new Consulta()
            {
                Id = 1,
                Sintoma = "Covid"
            };
        }

        public List<Consulta> ObterConsultas()
        {
            return new List<Consulta>()
            {
                new Consulta()
                {
                    Id = 1,
                    Sintoma = "Covid"
                },
                new Consulta()
                {
                    Id = 2,
                    Sintoma = "Virose"
                },
            };
        }
    }
}
