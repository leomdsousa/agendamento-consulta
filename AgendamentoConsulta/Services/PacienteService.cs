using AgendamentoConsulta.Models;
using AgendamentoConsulta.Repositorio.Interfaces;
using AgendamentoConsulta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoConsulta.Services
{
    public class PacienteService: IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Paciente>> GetAllPacientes()
        {
            try
            {
                return await _repository.GetAllPacientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Paciente> ObterPacienteByIdAsync(int? id)
        {
            try
            {
                return await _repository.ObterPacienteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Paciente> ObterPacienteByNomeAsync(string nomePaciente)
        {
            try
            {
                return await _repository.ObterPacienteByNomeAsync(nomePaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExistePacienteByNomeAsync(string nomePaciente)
        {
            try
            {
                return _repository.ExistePacienteByNomeAsync(nomePaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarPacienteAsync(int id)
        {
            try
            {
                var paciente = await _repository.ObterPacienteByIdAsync(id);

                if (paciente == null)
                    return;

                await _repository.DeletarPacienteAsync(paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AdicionarPacienteAsync(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                    return;

                await _repository.AdicionarPacienteAsync(paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditarPacienteAsync(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                    return;

                await _repository.EditarPacienteAsync(paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
