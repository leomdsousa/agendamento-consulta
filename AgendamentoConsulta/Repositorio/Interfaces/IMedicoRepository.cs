using AlbertEinsteinTeste.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Repositorio.Interfaces
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> GetAllMedicos();

        Task<Medico> ObterMedicoByIdAsync(int id);

        Task DeletarMedicoAsync(Medico medico);

        Task AdicionarMedicoAsync(Medico medico);

        Task EditarMedicoAsync(Medico medico);
    }
}
