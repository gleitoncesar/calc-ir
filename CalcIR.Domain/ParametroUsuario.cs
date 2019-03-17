using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class ParametroUsuario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public bool? ValorLogico { get; set; }
        public string ValorTexto { get; set; }
        public DateTime? ValorData { get; set; }
        public decimal ValorNumerico { get; set; }
    }
}
