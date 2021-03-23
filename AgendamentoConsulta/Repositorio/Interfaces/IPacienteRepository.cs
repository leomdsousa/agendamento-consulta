using AgendamentoConsulta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoConsulta.Repositorio.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllPacientes();

        Task<Paciente> ObterPacienteByIdAsync(int? id);

        Task<Paciente> ObterPacienteByNomeAsync(string nomePaciente);

        bool ExistePacienteByNomeAsync(string nomePaciente);

        Task DeletarPacienteAsync(Paciente paciente);

        Task AdicionarPacienteAsync(Paciente paciente);

        Task EditarPacienteAsync(Paciente paciente);
    }
}
