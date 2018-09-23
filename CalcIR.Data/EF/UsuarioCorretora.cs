using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class UsuarioCorretora
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdCorretora { get; set; }

        public Corretora IdCorretoraNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
