using CalcIR.Domain;
using CalcIR.Repository;
using CalcIR.Service.Validacao;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Service
{
    public class ResultadoService : BaseService
    {
        public ResultadoService() : base(){ }
        public ResultadoService(CalcIRContext context) : base(context) { }
        
        public void IncluirAcumulado(ResultadoAcumulado resultado)
        {
            var validacao = new ValidacaoResultadoAcumulado(base.Context);
            var resultadoValidacao = validacao.Validate(resultado);

            if (resultadoValidacao.IsValid)
            {
                Context.ResultadoAcumulado.Add(resultado);
                Context.TrySaveChanges();
            }
            else
            {
                throw new ValidationException(resultadoValidacao.Errors);
            }
        }

        internal void PrcessarResultado(Usuario usuario, DateTime dataPregao)
        {
            throw new NotImplementedException();
        }
    }
}
