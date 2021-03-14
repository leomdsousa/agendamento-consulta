using AlbertEinsteinTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<List<Medico>> GetAllMedicos();

        Task<Medico> ObterMedicoByIdAsync(int id);

        Task DeletarMedicoAsync(int id);

        Task AdicionarMedicoAsync(Medico medico);

        Task EditarMedicoAsync(Medico medico);
    }
}
