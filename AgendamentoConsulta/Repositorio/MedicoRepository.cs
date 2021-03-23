using AgendamentoConsulta.Data;
using AgendamentoConsulta.Models;
using AgendamentoConsulta.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsulta.Repositorio
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AlbertEinsteinTesteContext _context;

        public MedicoRepository(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Medico>> GetAllMedicos()
        {
            try
            {
                return await _context.Medico.OrderBy(x => x.Nome).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Medico> ObterMedicoByIdAsync(int id)
        {
            try
            {
                return await _context.Medico.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarMedicoAsync(Medico medico)
        {
            try
            {
                _context.Medico.Remove(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AdicionarMedicoAsync(Medico medico)
        {
            try
            {
                _context.Medico.Add(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditarMedicoAsync(Medico medico)
        {
            try
            {
                _context.Medico.Update(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
