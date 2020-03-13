using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services
{
    public class MedicoService
    {
        private readonly AlbertEinsteinTesteContext _context;
        public MedicoService(AlbertEinsteinTesteContext context)
        {
            _context = context;
        }

        public async Task<List<Medico>> GetAllMedicos()
        {
            return await _context.Medico.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Medico> ObterMedicoByIdAsync(int id)
        {
            return await _context.Medico.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeletarMedicoAsync(int id)
        {
            var medico = await _context.Medico.FirstOrDefaultAsync(x => x.Id == id);

            if (medico == null)
                return;

            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarMedicoAsync(Medico medico)
        {
            if (medico == null)
                return;

            _context.Medico.Add(medico);
            await _context.SaveChangesAsync();
        }

        public async Task EditarMedicoAsync(Medico medico)
        {
            if (medico == null)
                return;

            _context.Medico.Update(medico);
            await _context.SaveChangesAsync();
        }
    }
}
