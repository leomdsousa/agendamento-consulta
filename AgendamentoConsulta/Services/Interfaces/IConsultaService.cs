using AlbertEinsteinTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<bool> VerificaDuplicidadeDeConsultaPorMedicoeHorario(Consulta consulta);

        Task<List<Consulta>> BuscarConsultasAsync();

        Task<List<Consulta>> FiltraConsultasPorMedicoByIdAsync(int idMedico);

        Task<List<Consulta>> FiltraConsultasPorMedicoByNomeAsync(string nomeMedico);

        Task<List<Consulta>> FiltraConsultasPorPacienteByNomeAsync(string nomePaciente);

        Task<List<Consulta>> FiltraConsultasPorPacienteAsync(int idPaciente);

        Task<Consulta> ObterConsultaByIdAsync(int? id);

        Task AddConsultaAsync(Consulta consulta);

        Task AddConsultaPendenteAsync(Consulta consulta);

        Task RemoveAsync(int id);

        Task EditarConsultaAsync(Consulta consulta);

        Task<List<Consulta>> BuscarConsultasPendentesAsync();
    }
}
