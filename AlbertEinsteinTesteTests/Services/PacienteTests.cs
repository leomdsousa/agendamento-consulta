using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AlbertEinsteinTesteTests.Services
{
    public class PacienteTests
    {
        private readonly PacienteService _pacienteService;
        private readonly AlbertEinsteinTesteContext _context;
        private readonly AlbertEinsteinTesteMock _mock; 

        public PacienteTests()
        {
            //_context = new AlbertEinsteinTesteContext();
            _pacienteService = new PacienteService(_context);
            _mock = new AlbertEinsteinTesteMock();
        }

        [Fact(DisplayName = "ObterPacienteByIdAsync")]
        public void ObterPacienteByIdAsync()
        {
            //arrange
            int id = 1;
            _mock.PacienteService.Setup(x => x.ObterPacienteByIdAsync(id)).Returns(Task.FromResult(this.RetornaPaciente()));

            //act
            var result = _pacienteService.GetAllPacientes();

            //asset
            Assert.NotNull(result);
            Assert.IsType<Paciente>(result);
        }

        [Fact(DisplayName = "GetAllPacientes")]
        public void GetAllPacientes()
        {
            //arrange
            _mock.PacienteService.Setup(x => x.GetAllPacientes()).Returns(Task.FromResult(this.RetornaListaPaciente()));

            //act
            var result = _pacienteService.GetAllPacientes();

            //asset
            Assert.NotEmpty(result.Result);
            Assert.IsType<List<Paciente>>(result);
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
