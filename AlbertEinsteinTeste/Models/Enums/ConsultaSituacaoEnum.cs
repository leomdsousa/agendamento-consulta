using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Models.Enums
{
    public enum ConsultaSituacaoEnum
    {
        [Display(Name="Finalizada")] //Paciente já foi tratado
        Finalizada = 1,
        [Display(Name = "Aberta")] //Aguardando data da consulta, já confirmada
        Aberta = 2,
        [Display(Name = "Pendente")] //Aguardando confirmação
        Pendente = 3,
    }
}
