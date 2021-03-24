using AgendamentoConsulta.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AgendamentoConsulta.Models;

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
            //arrange
            _mock.MedicoRepository.Setup(x => x.GetAllMedicos()).Returns(Task.FromResult(this.ObterMedicos()));

            //act
            var result = await _medicoService.GetAllMedicos();

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Obter_Medico_By_Id()
        {
            //arrange
            int id = 1;

            _mock.MedicoRepository.Setup(x => x.ObterMedicoByIdAsync(id)).Returns(Task.FromResult(this.ObterMedico()));

            //act
            var result = await _medicoService.ObterMedicoByIdAsync(id);

            //assert
            Assert.NotNull(result);
        }

        private Medico ObterMedico()
        {
            return new Medico()
            {
                Id = 1,
                Nome = "Medico Teste 1"
            };
        }

        private List<Medico> ObterMedicos()
        {
            return new List<Medico>()
            {
                new Medico()
                {
                    Id = 1,
                    Nome = "Medico Teste"
                },
                new Medico()
                {
                    Id = 2,
                    Nome = "Medico Teste 2",
                }
            };
        }
    }
}
