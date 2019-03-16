using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class ResultadoOperacao
    {
        public ResultadoOperacao()
        {
            Papel = new Papel();
            Usuario = new Usuario();
        }

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Papel Papel { get; set; }
        public DateTime DataResultado { get; set; }
        public decimal Valor { get; set; }
    }
}
