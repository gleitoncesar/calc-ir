using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class ResultadoAcumulado
    {
        public int Id { get; set; }
        public DateTime DataResultado { get; set; }
        public string Mercado { get; set; }
        public decimal Valor { get; set; }
    }
}
