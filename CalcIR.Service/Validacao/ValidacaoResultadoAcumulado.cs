using CalcIR.Domain;
using CalcIR.Repository;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Service.Validacao
{
    public class ValidacaoResultadoAcumulado : AbstractValidator<ResultadoAcumulado>
    {
        private CalcIRContext Context { get; set; }
        private DateTime DataInicio = new DateTime(2015, 1, 1);

        public ValidacaoResultadoAcumulado(CalcIRContext context)
        {
            Context = context;
            RuleFor(p => p)
                .Must(NaoExisteResultadoPosterior)
                .WithMessage(Mensagem.ResulatdoAcumuladoPosteriorJaExiste);

            RuleFor(p => p.DataResultado)
                .GreaterThan(DataInicio)
                .WithMessage(Mensagem.ResulatdoAcumuladoDeveSerMaiorQue2015);

            RuleFor(p => p.Mercado)
                .NotEmpty();

            RuleFor(p => p.Usuario.Id)
                .GreaterThan(0)
                .WithMessage(Mensagem.UsuarioDeveSerInformado);
        }

        internal bool NaoExisteResultadoPosterior(ResultadoAcumulado resultado)
        {
            return !Context.ResultadoAcumulado
                .Any(p => p.Usuario.Id == resultado.Usuario.Id
                && p.DataResultado >= resultado.DataResultado
                && p.Mercado == resultado.Mercado);
        }
    }
}
