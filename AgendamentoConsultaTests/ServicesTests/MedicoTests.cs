using AgendamentoConsulta.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlbertEinsteinTesteTests.Services
{
    public class MedicoTests
    {
        private readonly MedicoService _medicoService;
        private readonly AlbertEinsteinTesteMock _mock;

        public MedicoTests()
        {
            _mock = new AlbertEinsteinTesteMock();
            _medicoService = new MedicoService(_mock.MedicoRepository.Object);
        }

        [Fact]
        public async void Get_All_Medicos()
        {
            //act
            var result = await _medicoService.GetAllMedicos();

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void Obter_Medico_By_Id()
        {
            //arrange
            int id = 1;

            //act
            var result = await _medicoService.ObterMedicoByIdAsync(id);

            //assert
            Assert.NotNull(result);
        }
    }
}
