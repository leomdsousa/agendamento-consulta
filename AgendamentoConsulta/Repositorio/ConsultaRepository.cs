using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Models.Enums;
using AlbertEinsteinTeste.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Repositorio
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly AlbertEinsteinTesteContext _context;

        public ConsultaRepository(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public bool VerificaDuplicidadeDeConsultaPorMedicoeHorario(Consulta consulta)
        {
            try
            {
                bool existeConsultaNoHorario = false;

                List<Consulta> consultasMedicoEscolhido = _context.Consulta.Include(x => x.Medico)
                                            .Where(x => x.Medico.Id == consulta.Medico.Id).ToList();

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
                return await _context.Consulta
                    .Include(x => x.Medico)
                    .Include(x => x.Paciente)
                    .Include(x => x.ConsultaSituacao)
                    .ToListAsync();
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
                return await _context.Consulta
                    .Include(x => x.Paciente)
                    .Include(x => x.Medico)
                    .Where(x => x.Id == idMedico)
                    .OrderByDescending(x => x.DataConsulta)
                    .ToListAsync();
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
                return await _context.Consulta
                    .Include(x => x.Paciente)
                    .Include(x => x.Medico)
                    .Where(x => x.Medico.Nome.ToLower().Contains(nomeMedico.ToLower()))
                    .OrderByDescending(x => x.DataConsulta)
                    .ToListAsync();
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
                return await _context.Consulta
                    .Include(x => x.Paciente)
                    .Include(x => x.Medico)
                    .Where(x => x.Paciente.Nome.ToLower().Contains(nomePaciente.ToLower()))
                    .OrderByDescending(x => x.DataConsulta)
                    .ToListAsync();
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
                return await _context.Consulta
                    .Where(x => x.Id == idPaciente)
                    .OrderByDescending(x => x.DataConsulta)
                    .ToListAsync();
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
                return await _context.Consulta
                    .Include(m => m.Medico)
                    .Include(p => p.Paciente)
                    .Include(c => c.ConsultaSituacao)
                    .FirstOrDefaultAsync(x => x.Id == id);
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

                _context.Consulta.Add(consulta);
                await _context.SaveChangesAsync();
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

                _context.Consulta.Update(consulta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(Consulta consulta)
        {
            try
            {
                if (consulta == null)
                    return;

                _context.Consulta.Remove(consulta);
                await _context.SaveChangesAsync();
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

                _context.Consulta.Update(consulta);
                await _context.SaveChangesAsync();
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
                return await _context.Consulta
                    .Include(x => x.Medico)
                    .Include(x => x.Paciente)
                    .Include(x => x.ConsultaSituacao)
                    .Where(x => x.ConsultaSituacaoId == 3) //Pendentes
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
