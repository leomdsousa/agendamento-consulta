using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AgendamentoConsulta.Models;
using AgendamentoConsulta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoConsulta.Controllers
{
    [Route("/Pacientes")]
    public class PacientesController : Controller
    {
        private readonly IPacienteService _pacienteService;
        public PacientesController(
            IPacienteService pacienteService
            )
        {
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Paciente> pacientes = await _pacienteService.GetAllPacientes();
                return View(pacientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("/Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pacienteService.DeletarPacienteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento." });
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento. Verifique os dados informados e tente novamente" });
                }

                await _pacienteService.AdicionarPacienteAsync(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Paciente não encontrado" });
                }

                await _pacienteService.EditarPacienteAsync(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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