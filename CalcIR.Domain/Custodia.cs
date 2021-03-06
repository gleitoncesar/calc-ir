﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Domain
{
    public class Custodia
    {
        public Custodia()
        {
            Papel = new Papel();
            Usuario = new Usuario();
        }

        public int Id { get; set; }
        public DateTime DataReferencia { get; set; }
        public Usuario Usuario { get; set; }
        public Papel Papel { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
