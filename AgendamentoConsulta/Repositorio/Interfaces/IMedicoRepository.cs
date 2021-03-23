using AgendamentoConsulta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoConsulta.Repositorio.Interfaces
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
