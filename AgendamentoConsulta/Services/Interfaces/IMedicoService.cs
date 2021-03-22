using AlbertEinsteinTeste.Models;
using System.Collections.Generic;
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
