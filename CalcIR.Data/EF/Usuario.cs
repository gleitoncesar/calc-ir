using System;
using System.Collections.Generic;

namespace CalcIR.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Nota = new HashSet<Nota>();
            Operacao = new HashSet<Operacao>();
            UsuarioCorretora = new HashSet<UsuarioCorretora>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public ICollection<Nota> Nota { get; set; }
        public ICollection<Operacao> Operacao { get; set; }
        public ICollection<UsuarioCorretora> UsuarioCorretora { get; set; }
    }
}
