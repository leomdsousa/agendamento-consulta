using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Models.Enums;
using AlbertEinsteinTeste.Models.ViewModels;
using AlbertEinsteinTeste.Repositorio.Interfaces;
using AlbertEinsteinTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _repository;

        public ConsultaService(IConsultaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> VerificaDuplicidadeDeConsultaPorMedicoeHorario(Consulta consulta)
        {
            try
            {
                bool existeConsultaNoHorario = false;

                List<Consulta> consultasMedicoEscolhido = await _repository.FiltraConsultasPorMedicoByIdAsync(consulta.Medico.Id);

                if (consultasMedicoEscolhido.Any(x => (x.DataConsulta - consulta.DataConsulta).TotalMinutes == 0))
                {
                    existeConsultaNoHorario = true;
                    return existeConsultaNoHorario;
                }

                return existeConsultaNoHorario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> BuscarConsultasAsync()
        {
            try
            {
                return await _repository.BuscarConsultasAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> FiltraConsultasPorMedicoByIdAsync(int idMedico)
        {
            try
            {
                return await _repository.FiltraConsultasPorMedicoByIdAsync(idMedico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> FiltraConsultasPorMedicoByNomeAsync(string nomeMedico)
        {
            try
            {
                return await _repository.FiltraConsultasPorMedicoByNomeAsync(nomeMedico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> FiltraConsultasPorPacienteByNomeAsync(string nomePaciente)
        {
            try
            {
                return await _repository.FiltraConsultasPorPacienteByNomeAsync(nomePaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> FiltraConsultasPorPacienteAsync(int idPaciente)
        {
            try
            {
                return await _repository.FiltraConsultasPorPacienteAsync(idPaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Consulta> ObterConsultaByIdAsync(int? id)
        {
            try
            {
                return await _repository.ObterConsultaByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddConsultaAsync(Consulta consulta)
        {
            try
            {
                if (consulta == null)
                    return;

                await _repository.AddConsultaAsync(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddConsultaPendenteAsync(Consulta consulta)
        {
            try
            {
                if (consulta == null)
                    return;

                consulta.ConsultaSituacaoId = (int)ConsultaSituacaoEnum.Aberta;

                await _repository.AddConsultaPendenteAsync(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var consulta = await _repository.ObterConsultaByIdAsync(id);

                if (consulta == null)
                    return;

                await _repository.RemoveAsync(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditarConsultaAsync(Consulta consulta)
        {
            try
            {
                if (consulta == null)
                    return;

                await _repository.EditarConsultaAsync(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Consulta>> BuscarConsultasPendentesAsync()
        {
            try
            {
                return await _repository.BuscarConsultasPendentesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
