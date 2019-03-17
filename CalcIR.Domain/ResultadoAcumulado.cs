using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class ResultadoAcumulado
    {
        public ResultadoAcumulado()
        {
            Usuario = new Usuario();
        }

        public int Id { get; set; }
        public DateTime DataResultado { get; set; }
        public Usuario Usuario { get; set; }
        public char Mercado { get; set; }
        public decimal Valor { get; set; }
    }
}
