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
    public class PacientesController : Controller
    {
        private readonly PacienteService _pacienteService;
        public PacientesController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> Index()
        {
            List<Paciente> pacientes = await _pacienteService.GetAllPacientes();
            return View(pacientes);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });
            }

            Paciente paciente = await _pacienteService.ObterPacienteByIdAsync(id);
            if (paciente == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Paciente não encontrado" });
            }

            return View(paciente);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pacienteService.DeletarPacienteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento." });
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento. Verifique os dados informados e tente novamente" });
            }

            await _pacienteService.AdicionarPacienteAsync(paciente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });
            }

            Paciente paciente = await _pacienteService.ObterPacienteByIdAsync(id.Value);
            if (paciente == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Paciente não encontrado" });
            }

            return View(paciente);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Paciente paciente)
        {
            if (paciente == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Paciente não encontrado" });
            }

            await _pacienteService.EditarPacienteAsync(paciente);
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