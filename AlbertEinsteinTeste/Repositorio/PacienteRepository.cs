using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Repositorio
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AlbertEinsteinTesteContext _context;

        public PacienteRepository(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> GetAllPacientes()
        {
            try
            {
                return await _context.Paciente.OrderByDescending(x => x.Nome).ToListAsync();
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
                return await _context.Paciente.FirstOrDefaultAsync(x => x.Id == id);
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
                return await _context.Paciente.FirstOrDefaultAsync(x => x.Nome.ToLower().Contains(nomePaciente.ToLower()));
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
                return _context.Paciente.Any(x => x.Nome.ToLower().Contains(nomePaciente.ToLower()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarPacienteAsync(Paciente paciente)
        {
            try
            {
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();
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

                _context.Paciente.Add(paciente);
                await _context.SaveChangesAsync();
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

                _context.Paciente.Update(paciente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
