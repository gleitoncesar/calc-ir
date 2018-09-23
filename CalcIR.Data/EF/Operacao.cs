using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Operacao
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdPapel { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorMedio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal? Resultado { get; set; }

        public Papel IdPapelNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
