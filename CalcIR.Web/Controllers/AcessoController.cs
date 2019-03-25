using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalcIR.Repository;
using CalcIR.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CalcIR.Domain;

namespace CalcIR.Web.Controllers
{
    public class AcessoController : Controller
    {
        AcessoService service = null;
        
        public AcessoController(CalcIRContext context)
        {
            service = new AcessoService(context);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/Acesso/LoginCallback" }, "Google");
        }

        [AllowAnonymous]
        public IActionResult LoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = ((ClaimsIdentity)User.Identity);
                Claim email = identity.FindFirst(ClaimTypes.Email);
                
                if (!service.UsuarioExiste(email.Value))
                {
                    Claim nome = identity.FindFirst(ClaimTypes.Name);
                    Claim idExterno = identity.FindFirst(ClaimTypes.NameIdentifier);

                    var usuario = new Usuario();
                    usuario.Apelido = nome.Value;
                    usuario.Nome = nome.Value;
                    usuario.Email = email.Value;
                    usuario.IdExterno = idExterno.Value;
                    usuario.DataCadastro = DateTime.Now;

                    service.Incluir(usuario);
                }

                return Redirect("/Custodia");
            }

            return Redirect("/");
        }
    }
}
