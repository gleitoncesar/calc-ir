using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Nota
    {
        public Nota()
        {
            Negocio = new HashSet<Negocio>();
        }

        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdCorretora { get; set; }
        public DateTime DataPregao { get; set; }
        public decimal ValorLiquido { get; set; }

        public Corretora IdCorretoraNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Negocio> Negocio { get; set; }
    }
}
