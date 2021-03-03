using AlbertEinsteinTeste.Services;
using AlbertEinsteinTesteTests.Mock;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
