using AlbertEinsteinTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetAllPacientes();

        Task<Paciente> ObterPacienteByIdAsync(int? id);

        Task<Paciente> ObterPacienteByNomeAsync(string nomePaciente);

        bool ExistePacienteByNomeAsync(string nomePaciente);

        Task DeletarPacienteAsync(int id);

        Task AdicionarPacienteAsync(Paciente paciente);

        Task EditarPacienteAsync(Paciente paciente);
    }
}
