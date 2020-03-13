using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });
            }

            Medico medico = await _medicoService.ObterMedicoByIdAsync(id.Value);
            if (medico == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Médico não encontrado" });
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
                return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante o processamento" });
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
                return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento. Verifique os dados informados e tente novamente" });
            }

            await _medicoService.AdicionarMedicoAsync(consulta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });
            }

            Medico medico = await _medicoService.ObterMedicoByIdAsync(id.Value);
            if (medico == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Médico não encontrado" });
            }

            return View(medico);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medico medico)
        {
            if (medico == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Médico não encontrado" });
            }

            await _medicoService.EditarMedicoAsync(medico);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Erro(string mensagem)
        {
            return View(new ErroViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                ,
                Mensagem = mensagem
            });
        }
    }
}