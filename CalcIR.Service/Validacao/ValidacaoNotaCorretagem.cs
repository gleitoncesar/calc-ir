using CalcIR.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalcIR.Service.Validacao
{
    public class ValidacaoNotaCorretagem : AbstractValidator<NotaCorretagem>
    {
        public ValidacaoNotaCorretagem()
        {
            RuleFor(p => p.DataLiquidacao)
                .GreaterThan(p => p.DataPregao);

            RuleFor(p => p.Usuario.Id)
                .GreaterThan(0)
                .WithMessage(Mensagem.UsuarioDeveSerInformado);

            RuleFor(p => p)
                .Must(TotalNotaOK)
                .WithMessage(Mensagem.NotaCorretagemTotalInvalido);

            RuleForEach(p => p.ListaOperacao)
                .SetValidator(new ValidacaoOperacao());
        }

        internal bool TotalNotaOK(NotaCorretagem nota)
        {
            var totalOperacao = nota.ListaOperacao
                .Sum(p => p.Tipo == (char)TipoOperacao.Compra ? -p.ValorOperacao : p.ValorOperacao);

            var totalCalculado = Math.Abs(totalOperacao - nota.TaxaLiquidacao - nota.TaxaRegistro - nota.TotalBovespa - nota.TotalCorretagem);

            return totalCalculado == nota.Valorliquido;
        }
    }
}
