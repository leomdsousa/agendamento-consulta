using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AgendamentoConsulta.Models;
using AgendamentoConsulta.Models.Enums;
using AgendamentoConsulta.Models.ViewModels;
using AgendamentoConsulta.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoConsulta.Controllers
{
    [Route("/Consultas")]
    public class ConsultasController : Controller
    {
        private readonly IConsultaService _consultaService;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;

        public ConsultasController(
            IConsultaService consultaService,
            IMedicoService medicoService,
            IPacienteService pacienteService
            )
        {
            _consultaService = consultaService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Consulta> listaConsultas = await _consultaService.BuscarConsultasAsync();
                return View(listaConsultas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("IndexPaciente")]
        public async Task<IActionResult> IndexPaciente()
        {
            try
            {
                List<Consulta> listaConsultas = await _consultaService.BuscarConsultasAsync();
                return View(listaConsultas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ConsultasPorMedico")]
        public async Task<IActionResult> ConsultasPorMedico(string nomeMedico)
        {
            try
            {
                if (string.IsNullOrEmpty(nomeMedico))
                    return View(RedirectToAction(nameof(Index)));

                List<Consulta> listaConsultasPorMedico = await _consultaService.FiltraConsultasPorMedicoByNomeAsync(nomeMedico);
                return View(listaConsultasPorMedico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ConsultasPorPaciente")]
        public async Task<IActionResult> ConsultasPorPaciente(string nomePaciente)
        {
            try
            {
                if (string.IsNullOrEmpty(nomePaciente))
                    return View(RedirectToAction(nameof(Index)));

                List<Consulta> listaConsultasPorPaciente = await _consultaService.FiltraConsultasPorPacienteByNomeAsync(nomePaciente);
                return View(listaConsultasPorPaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                List<Medico> medicos = await _medicoService.GetAllMedicos();
                var consultaViewModel = new ConsultaFormViewModel { Medicos = medicos };
                return View(consultaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Consulta consulta)
        {
            try
            {
                consulta.ConsultaSituacaoId = (int)ConsultaSituacaoEnum.Aberta;

                if (!ModelState.IsValid)
                {
                    List<Medico> medicos = await _medicoService.GetAllMedicos();
                    ConsultaFormViewModel consultaFormViewModel = new ConsultaFormViewModel
                    {
                        Consulta = consulta,
                        Medicos = medicos
                    };

                    return View(consultaFormViewModel);
                }

                if (await _consultaService.VerificaDuplicidadeDeConsultaPorMedicoeHorario(consulta))
                    return RedirectToAction(nameof(Erro), new { mensagem = "Já existe consulta marcada para a data e horário informados com o mesmo médico" });

                await _consultaService.AddConsultaAsync(consulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("AgendarConsulta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgendarConsulta()
        {
            try
            {
                List<Medico> medicos = await _medicoService.GetAllMedicos();
                var consultaViewModel = new ConsultaFormViewModel { Medicos = medicos };
                return View(consultaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgendarConsulta(ConsultaFormViewModel agendamentoConsulta, IFormCollection form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<Medico> medicos = await _medicoService.GetAllMedicos();
                    ConsultaFormViewModel consultaFormViewModel = new ConsultaFormViewModel
                    {
                        Consulta = agendamentoConsulta.Consulta,
                        Medico = agendamentoConsulta.Medico
                    };

                    return View(consultaFormViewModel);
                }

                agendamentoConsulta.Consulta.ConsultaSituacaoId = (int)ConsultaSituacaoEnum.Pendente;
                int idMedico = Convert.ToInt32(Request.Form["Medicos"]);
                agendamentoConsulta.Consulta.Medico = await _medicoService.ObterMedicoByIdAsync(idMedico);

                if (await _consultaService.VerificaDuplicidadeDeConsultaPorMedicoeHorario(agendamentoConsulta.Consulta))
                    return RedirectToAction(nameof(Erro), new { mensagem = "Já existe consulta marcada para a data e horário informados com o mesmo médico" });

                if (!_pacienteService.ExistePacienteByNomeAsync(agendamentoConsulta.Paciente.Nome))
                    await _pacienteService.AdicionarPacienteAsync(agendamentoConsulta.Paciente);

                agendamentoConsulta.Consulta.Paciente = await _pacienteService.ObterPacienteByNomeAsync(agendamentoConsulta.Paciente.Nome);

                await _consultaService.AddConsultaAsync(agendamentoConsulta.Consulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });
                }

                Consulta consulta = await _consultaService.ObterConsultaByIdAsync(id);
                if (consulta == null)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Consulta não encontrada" });
                }

                return View(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _consultaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Houve um erro durante processamento" });
            }
        }

        [HttpGet("Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });

                Consulta consulta = await _consultaService.ObterConsultaByIdAsync(id);
                return View(consulta);
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Consulta consulta)
        {
            try
            {
                if (consulta == null)
                {
                    return RedirectToAction(nameof(Erro), new { mensagem = "Consulta não encontrada" });
                }

                await _consultaService.EditarConsultaAsync(consulta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }

        [HttpGet("ConsultasPendentes")]
        public async Task<IActionResult> ConsultasPendentes()
        {
            try
            {
                List<Consulta> listaConsultas = await _consultaService.BuscarConsultasPendentesAsync();
                return View(listaConsultas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ConsultasPendentes/{id?}")]
        public async Task<IActionResult> ConfirmarAgendamento(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });

                Consulta consulta = await _consultaService.ObterConsultaByIdAsync(id.Value);

                if (consulta == null)
                    return RedirectToAction(nameof(Erro), new { mensagem = "Consulta não encontrada" });

                await _consultaService.AddConsultaPendenteAsync(consulta);
                return RedirectToAction(nameof(ConsultasPendentes));
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
                , Mensagem = mensagem
            });
        }
    }
}