using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Papel
    {
        public Papel()
        {
            Negocio = new HashSet<Negocio>();
            Operacao = new HashSet<Operacao>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public ICollection<Negocio> Negocio { get; set; }
        public ICollection<Operacao> Operacao { get; set; }
    }
}
