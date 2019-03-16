using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class NotaCorretagem
    {
        public NotaCorretagem()
        {
            ListaOperacao = new List<Operacao>();
            Usuario = new Usuario();
        }

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int Numero { get; set; }
        public DateTime DataPregao { get; set; }
        public DateTime DataLiquidacao { get; set; }
        public decimal TaxaLiquidacao { get; set; }
        public decimal TaxaRegistro { get; set; }
        public decimal TotalBovespa { get; set; }
        public decimal TotalCorretagem { get; set; }
        public decimal Valorliquido { get; set; }
        public List<Operacao> ListaOperacao { get; set; }
    }
}
