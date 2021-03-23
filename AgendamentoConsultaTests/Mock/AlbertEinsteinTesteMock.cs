using AgendamentoConsulta.Repositorio.Interfaces;
using AgendamentoConsulta.Services.Interfaces;
using Moq;

namespace AlbertEinsteinTesteTests.Mock
{
    public class AlbertEinsteinTesteMock
    {
        #region SERVICE

        public Mock<IPacienteService> PacienteService { get; set; }
        public Mock<IConsultaService> ConsultaService { get; set; }
        public Mock<IMedicoService> MedicoService { get; set; }

        #endregion SERVICE

        #region REPOSITORIO

        public Mock<IPacienteRepository> PacienteRepository { get; set; }
        public Mock<IConsultaRepository> ConsultaRepository { get; set; }
        public Mock<IMedicoRepository> MedicoRepository { get; set; }

        #endregion REPOSITORIO

        public AlbertEinsteinTesteMock()
        {
            #region SERVICE

            PacienteService = new Mock<IPacienteService>();

            ConsultaService = new Mock<IConsultaService>();

            MedicoService = new Mock<IMedicoService>();

            #endregion SERVICE

            #region REPOSITORIO

            PacienteRepository = new Mock<IPacienteRepository>();

            ConsultaRepository = new Mock<IConsultaRepository>();

            MedicoRepository = new Mock<IMedicoRepository>();

            #endregion REPOSITORIO
        }

    }
}
