using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class Operacao
    {
        public int Id { get; set; }
        public Papel Papel { get; set; }
        public bool DayTrade { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorOperacao { get; set; }
        public char Tipo { get; set; }
    }
}
