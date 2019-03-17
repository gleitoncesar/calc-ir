using CalcIR.Domain;
using CalcIR.Repository;
using CalcIR.Service.Validacao;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Service
{
    public class NotaCorretagemService : BaseService
    {
        private ResultadoService resultadoService = null;
        private CustodiaService custodiaService = null;

        public NotaCorretagemService() : base()
        {
            InstanciarServicos();
        }

        public NotaCorretagemService(CalcIRContext context) : base(context)
        {
            InstanciarServicos();
        }

        private void InstanciarServicos()
        {
            resultadoService = new ResultadoService();
            custodiaService = new CustodiaService();
        }

        public NotaCorretagem Incluir(NotaCorretagem nota)
        {
            var validacao = new ValidacaoNotaCorretagem();
            var resultadoValidacao = validacao.Validate(nota);

            if (resultadoValidacao.IsValid)
            {
                Context.NotaCorretagem.Add(nota);
                Context.TrySaveChanges();
                resultadoService.PrcessarResultado(nota.Usuario, nota.DataPregao);
                custodiaService.PrcessarCustodia(nota.Usuario, nota.DataPregao);
            }
            else
            {
                throw new ValidationException(resultadoValidacao.Errors);
            }

            return nota;
        }
    }
}
