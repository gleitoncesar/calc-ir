using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Corretora
    {
        public Corretora()
        {
            Nota = new HashSet<Nota>();
            UsuarioCorretora = new HashSet<UsuarioCorretora>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Nota> Nota { get; set; }
        public ICollection<UsuarioCorretora> UsuarioCorretora { get; set; }
    }
}
