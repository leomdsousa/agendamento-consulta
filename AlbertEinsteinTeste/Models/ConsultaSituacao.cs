﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbertEinsteinTeste.Models
{
    public class ConsultaSituacao
    {
        public int Id { get; set; }
        public string DescricaoSituacao { get; set; }

        public ConsultaSituacao()
        {
        }
        public ConsultaSituacao(string descricao)
        {
            DescricaoSituacao = descricao;
        }
    }
}