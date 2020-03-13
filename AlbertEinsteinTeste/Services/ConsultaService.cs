using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Models.Enums;
using AlbertEinsteinTeste.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services
{
    public class ConsultaService
    {
        private readonly AlbertEinsteinTesteContext _context;
        private readonly PacienteService _pacienteService;
        public ConsultaService(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public bool VerificaDuplicidadeDeConsultaPorMedicoeHorario(Consulta consulta)
        {
            if(_context.Consulta.Any(x => x.Paciente == consulta.Paciente
                                    && x.DataConsulta.Day == consulta.DataConsulta.Day))
            {
                return false;
            }

            return true;
        }

        public async Task<List<Consulta>> BuscarConsultasAsync()
        {
            return await _context.Consulta
                        .Include(x => x.Medico)
                        .Include(x => x.Paciente)
                        .Include(x => x.ConsultaSituacao)
                        .ToListAsync();
        }

        public async Task<List<Consulta>> FiltraConsultasPorMedicoByIdAsync(int idMedico)
        {
            return await _context.Consulta
                        .Include(x => x.Paciente)
                        .Include(x => x.Medico)
                        .Where(x => x.Id == idMedico)
                        .OrderByDescending(x => x.DataConsulta)
                        .ToListAsync();
        }

        public async Task<List<Consulta>> FiltraConsultasPorMedicoByNomeAsync(string nomeMedico)
        {
            return await _context.Consulta
                        .Include(x => x.Paciente)
                        .Include(x => x.Medico)
                        .Where(x => x.Medico.Nome.ToLower().Contains(nomeMedico.ToLower()))
                        .OrderByDescending(x => x.DataConsulta)
                        .ToListAsync();
        }

        public async Task<List<Consulta>> FiltraConsultasPorPacienteByNomeAsync(string nomePaciente)
        {
            return await _context.Consulta
                        .Include(x => x.Paciente)
                        .Include(x => x.Medico)
                        .Where(x => x.Paciente.Nome.ToLower().Contains(nomePaciente.ToLower()))
                        .OrderByDescending(x => x.DataConsulta)
                        .ToListAsync();
        }

        public async Task<List<Consulta>> FiltraConsultasPorPacienteAsync(int idPaciente)
        {
            return await _context.Consulta
                        .Where(x => x.Id == idPaciente)
                        .OrderByDescending(x => x.DataConsulta)
                        .ToListAsync();
        }

        public async Task<Consulta> ObterConsultaByIdAsync(int? id)
        {
            return await _context.Consulta
                        .Include(m => m.Medico)
                        .Include(p => p.Paciente)
                        .Include(c => c.ConsultaSituacao)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddConsultaAsync(Consulta consulta)
        {
            if (consulta == null)
                return;

            if(!VerificaDuplicidadeDeConsultaPorMedicoeHorario(consulta))
            {
                return;
            }

            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task AddConsultaPendenteAsync(Consulta consulta)
        {
            if (consulta == null)
                return;

            consulta.ConsultaSituacaoId = (int)ConsultaSituacaoEnum.Aberta;

            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var consulta = await _context.Consulta.FirstOrDefaultAsync(x => x.Id == id);

            if (consulta == null)
                return;

            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task EditarConsultaAsync(Consulta consulta)
        {
            if (consulta == null)
                return;

            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();

        }

        internal async Task<List<Consulta>> BuscarConsultasPendentesAsync()
        {
            return await _context.Consulta
                        .Include(x => x.Medico)
                        .Include(x => x.Paciente)
                        .Include(x => x.ConsultaSituacao)
                        .Where(x => x.ConsultaSituacaoId == 3) //Pendentes
                        .ToListAsync();
        }
    }
}
