using AgendamentoConsulta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoConsulta.Repositorio.Interfaces
{
    public interface IConsultaRepository
    {
        bool VerificaDuplicidadeDeConsultaPorMedicoeHorario(Consulta consulta);

        Task<List<Consulta>> BuscarConsultasAsync();

        Task<List<Consulta>> FiltraConsultasPorMedicoByIdAsync(int idMedico);

        Task<List<Consulta>> FiltraConsultasPorMedicoByNomeAsync(string nomeMedico);

        Task<List<Consulta>> FiltraConsultasPorPacienteByNomeAsync(string nomePaciente);

        Task<List<Consulta>> FiltraConsultasPorPacienteAsync(int idPaciente);

        Task<Consulta> ObterConsultaByIdAsync(int? id);

        Task AddConsultaAsync(Consulta consulta);

        Task AddConsultaPendenteAsync(Consulta consulta);

        Task RemoveAsync(Consulta consulta);

        Task EditarConsultaAsync(Consulta consulta);

        Task<List<Consulta>> BuscarConsultasPendentesAsync();
    }
}
