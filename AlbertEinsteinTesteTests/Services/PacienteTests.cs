using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Services;
using AlbertEinsteinTesteTests.Mock;
using Moq;
using Xunit;

namespace AlbertEinsteinTesteTests.Services
{
    public class PacienteTests
    {
        private readonly PacienteService _pacienteService;
        private readonly AlbertEinsteinTesteMock _mock; 

        public PacienteTests()
        {
            _mock = new AlbertEinsteinTesteMock();
            _pacienteService = new PacienteService(_mock.PacienteRepository.Object);
        }

        [Fact(DisplayName = "ObterPacienteByIdAsync")]
        public void ObterPacienteByIdAsync()
        {
            //arrange
            int id = 1;
            _mock.PacienteRepository.Setup(x => x.ObterPacienteByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(this.RetornaPaciente()));

            //act
            var result = _pacienteService.ObterPacienteByIdAsync(id);

            //asset
            Assert.NotNull(result.Result);
            Assert.IsType<Paciente>(result.Result);
        }

        [Fact(DisplayName = "GetAllPacientes")]
        public void GetAllPacientes()
        {
            //arrange
            _mock.PacienteRepository.Setup(x => x.GetAllPacientes()).Returns(Task.FromResult(this.RetornaListaPaciente()));

            //act
            var result = _pacienteService.GetAllPacientes();

            //asset
            Assert.NotEmpty(result.Result);
            Assert.IsType<List<Paciente>>(result.Result);
        }

        #region METODOS AUXILIARES

        private Paciente RetornaPaciente()
        {
            return new Paciente();
        }

        private List<Paciente> RetornaListaPaciente()
        {
            return new List<Paciente>()
            {
                new Paciente()
            };
        }

        #endregion METODOS AUXILIARES
    }
}
