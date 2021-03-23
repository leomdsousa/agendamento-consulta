using AgendamentoConsulta.Models;
using AgendamentoConsulta.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;
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
            Consulta consulta = new Consulta(); 

            //act
            var result = await _consultaService.VerificaDuplicidadeDeConsultaPorMedicoeHorario(consulta);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async void Obter_Consulta_By_Id()
        {
            //arrange
            int id = 1;

            //act
            var result = await _consultaService.ObterConsultaByIdAsync(id);

            //assert
            Assert.NotNull(result);
        }
    }
}
