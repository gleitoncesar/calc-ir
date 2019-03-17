using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class Usuario
    {
        public Usuario()
        {
            ListaParametro = new List<ParametroUsuario>();
        }

        public int Id { get; set; }
        public string Apelido { get; set; }
        public List<ParametroUsuario> ListaParametro { get; set; }
    }
}