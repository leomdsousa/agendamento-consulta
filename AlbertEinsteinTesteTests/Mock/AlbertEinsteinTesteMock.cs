using AlbertEinsteinTeste.Services.Interfaces;
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

        public AlbertEinsteinTesteMock()
        {
            #region SERVICE

            PacienteService = new Mock<IPacienteService>();

            ConsultaService = new Mock<IConsultaService>();

            MedicoService = new Mock<IMedicoService>();

            #endregion SERVICE
        }

    }
}
