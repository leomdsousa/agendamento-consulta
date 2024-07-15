using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AgendamentoConsulta.Models;
using AgendamentoConsulta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoConsulta.Controllers
{
    //[ValidateAntiForgeryToken]
    public class MedicosController : Controller
    {
        private readonly IMedicoService _medicoService; 
        public MedicosController(
            IMedicoService medicoService
            )
        {
            _medicoService = medicoService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Medico> medicos = await _medicoService.GetAllMedicos();
                return View(medicos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medico consulta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Erro durante processamento. Verifique os dados informados e tente novamente" });
                }

                await _medicoService.AdicionarMedicoAsync(consulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Medico medico)
        {
            try
            {
                if (medico == null)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Médico não encontrado" });
                }

                await _medicoService.EditarMedicoAsync(medico);
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