using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Mercado
    {
        public Mercado()
        {
            Negocio = new HashSet<Negocio>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Negocio> Negocio { get; set; }
    }
}
