using AlbertEinsteinTeste.Data;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Repositorio.Interfaces;
using AlbertEinsteinTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Medico>> GetAllMedicos()
        {
            try
            {
                return await _repository.GetAllMedicos();
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
                return await _repository.ObterMedicoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarMedicoAsync(int id)
        {
            try
            {
                var medico = await _repository.ObterMedicoByIdAsync(id);

                if (medico == null)
                    return;

                await _repository.DeletarMedicoAsync(medico);
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
                if (medico == null)
                    return;

                await _repository.AdicionarMedicoAsync(medico);
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
                if (medico == null)
                    return;

                await _repository.EditarMedicoAsync(medico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
