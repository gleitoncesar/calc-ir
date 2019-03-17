using CalcIR.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Service.Validacao
{
    public class ValidacaoOperacao : AbstractValidator<Operacao>
    {
        public ValidacaoOperacao()
        {
            RuleFor(p => p.ValorOperacao)
                .Equal(p => p.Quantidade * p.Preco);
        }
    }
}
