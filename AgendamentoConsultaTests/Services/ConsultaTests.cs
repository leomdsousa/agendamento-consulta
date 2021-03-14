using AlbertEinsteinTeste.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
