using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Negocio
    {
        public long Id { get; set; }
        public long IdNota { get; set; }
        public long IdMercado { get; set; }
        public long IdTipoNegocio { get; set; }
        public long IdPapel { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoAjustado { get; set; }

        public Mercado IdMercadoNavigation { get; set; }
        public Nota IdNotaNavigation { get; set; }
        public Papel IdPapelNavigation { get; set; }
        public TipoNegocio IdTipoNegocioNavigation { get; set; }
    }
}
