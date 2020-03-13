using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services
{
    public class PacienteService
    {
        private readonly AlbertEinsteinTesteContext _context;
        public PacienteService(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> GetAllPacientes()
        {
            return await _context.Paciente.OrderByDescending(x => x.Nome).ToListAsync();
        }
        public async Task<Paciente> ObterPacienteByIdAsync(int? id)
        {
            return await _context.Paciente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Paciente> ObterPacienteByNomeAsync(string nomePaciente)
        {
            return await _context.Paciente.FirstOrDefaultAsync(x => x.Nome.ToLower().Contains(nomePaciente.ToLower()));
        }

        public bool ExistePacienteByNomeAsync(string nomePaciente)
        {
            return _context.Paciente.Any(x => x.Nome.ToLower().Contains(nomePaciente.ToLower()));
        }

        public async Task DeletarPacienteAsync(int id)
        {
            var paciente = await _context.Paciente.FirstOrDefaultAsync(x => x.Id == id);

            if (paciente == null)
                return;

            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarPacienteAsync(Paciente paciente)
        {
            if (paciente == null)
                return;

            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task EditarPacienteAsync(Paciente paciente)
        {
            if (paciente == null)
                return;

            _context.Paciente.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
