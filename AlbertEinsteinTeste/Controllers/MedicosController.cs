using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbertEinsteinTeste.Controllers
{
    public class MedicosController : Controller
    {
        private readonly MedicoService _medicoService; 
        public MedicosController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public async Task<IActionResult> Index()
        {
            List<Medico> medicos = await _medicoService.GetAllMedicos();
            return View(medicos);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medico medico = await _medicoService.ObterMedicoByIdAsync(id.Value);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _medicoService.DeletarMedicoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _medicoService.AdicionarMedicoAsync(consulta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Medico medico = await _medicoService.ObterMedicoByIdAsync(id.Value);
            if (medico == null)
            {
                return BadRequest();
            }

            return View(medico);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medico medico)
        {
            if (medico == null)
            {
                return BadRequest();
            }

            await _medicoService.EditarMedicoAsync(medico);
            return RedirectToAction(nameof(Index));
        }
    }
}