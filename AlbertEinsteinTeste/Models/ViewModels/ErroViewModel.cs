using System;

namespace AlbertEinsteinTeste.Models
{
    public class ErroViewModel
    {
        public string RequestId { get; set; }
        public string Mensagem { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}