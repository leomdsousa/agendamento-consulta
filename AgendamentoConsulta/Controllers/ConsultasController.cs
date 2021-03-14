using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AlbertEinsteinTeste.Models;
using AlbertEinsteinTeste.Models.Enums;
using AlbertEinsteinTeste.Models.ViewModels;
using AlbertEinsteinTeste.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlbertEinsteinTeste.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ConsultaService _consultaService;
        private readonly MedicoService _medicoService;
        private readonly PacienteService _pacienteService;
        public ConsultasController(ConsultaService consultaService, MedicoService medicoService, PacienteService pacienteService)
        {
            _consultaService = consultaService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> Index()
        {
            List<Consulta> listaConsultas = await _consultaService.BuscarConsultasAsync();
            return View(listaConsultas);
        }

        public async Task<IActionResult> IndexPaciente()
        {
            List<Consulta> listaConsultas = await _consultaService.BuscarConsultasAsync();
            return View(listaConsultas);
        }

        public async Task<IActionResult> ConsultasPorMedico(string nomeMedico)
        {
            if (string.IsNullOrEmpty(nomeMedico))
                return View(RedirectToAction(nameof(Index)));

            List<Consulta> listaConsultasPorMedico = await _consultaService.FiltraConsultasPorMedicoByNomeAsync(nomeMedico);
            return View(listaConsultasPorMedico);
        }

        public async Task<IActionResult> ConsultasPorPaciente(string nomePaciente)
        {
            if (string.IsNullOrEmpty(nomePaciente))
                return View(RedirectToAction(nameof(Index)));

            List<Consulta> listaConsultasPorPaciente = await _consultaService.FiltraConsultasPorPacienteByNomeAsync(nomePaciente);
            return View(listaConsultasPorPaciente);
        }

        public async Task<IActionResult> Create()
        {
            List<Medico> medicos = await _medicoService.GetAllMedicos();
            var consultaViewModel = new ConsultaFormViewModel { Medicos = medicos };
            return View(consultaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consulta consulta)
        {
            consulta.ConsultaSituacaoId = (int)ConsultaSituacaoEnum.Aberta;

            if (!ModelState.IsValid)
            {
                List<Medico> medicos = await _medicoService.GetAllMedicos();
                ConsultaFormViewModel consultaFormViewModel = new ConsultaFormViewModel
                {
                    Consulta = consulta, Medicos = medicos
                };

                return View(consultaFormViewModel);
            }

            if(await _consultaService.VerificaDuplicidadeDeConsultaPorMedicoeHorario(consulta))
                return RedirectToAction(nameof(Erro), new { mensagem = "Já existe consulta marcada para a data e horário informados com o mesmo médico" });

            await _consultaService.AddConsultaAsync(consulta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AgendarConsulta()
        {
            List<Medico> medicos = await _medicoService.GetAllMedicos();
            var consultaViewModel = new ConsultaFormViewModel { Medicos = medicos };
            return View(consultaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgendarConsulta(ConsultaFormViewModel agendamentoConsulta, IFormCollection form)
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

            if(!_pacienteService.ExistePacienteByNomeAsync(agendamentoConsulta.Paciente.Nome))
                await _pacienteService.AdicionarPacienteAsync(agendamentoConsulta.Paciente);

            agendamentoConsulta.Consulta.Paciente = await _pacienteService.ObterPacienteByNomeAsync(agendamentoConsulta.Paciente.Nome);


            await _consultaService.AddConsultaAsync(agendamentoConsulta.Consulta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpDelete]
        [ValidateAntiForgeryToken]
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });

            Consulta consulta = await _consultaService.ObterConsultaByIdAsync(id);
            return View(consulta);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Consulta consulta)
        {
            if (consulta == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Consulta não encontrada" });
            }

            await _consultaService.EditarConsultaAsync(consulta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ConsultasPendentes()
        {
            List<Consulta> listaConsultas = await _consultaService.BuscarConsultasPendentesAsync();
            return View(listaConsultas);
        }

        public async Task<IActionResult> ConfirmarAgendamento(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Erro), new { mensagem = "Id nulo" });

            Consulta consulta = await _consultaService.ObterConsultaByIdAsync(id.Value);

            if (consulta == null)
                return RedirectToAction(nameof(Erro), new { mensagem = "Consulta não encontrada" });

            await _consultaService.AddConsultaPendenteAsync(consulta);
            return RedirectToAction(nameof(ConsultasPendentes));
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