using AlbertEinsteinTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Repositorio.Interfaces
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
