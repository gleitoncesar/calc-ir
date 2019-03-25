using CalcIR.Domain;
using CalcIR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalcIR.Service
{
    public class AcessoService : BaseService
    {
        public AcessoService() : base()
        {
            
        }

        public AcessoService(CalcIRContext context) : base(context)
        {
        }

        public bool UsuarioExiste(string email)
        {
            return Context.Usuario.Any(p => p.Email == email);
        }

        public void Incluir(Usuario usuario)
        {
            Context.Usuario.Add(usuario);
            Context.TrySaveChanges();
        }
    }
}
