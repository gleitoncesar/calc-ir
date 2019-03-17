using CalcIR.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace CalcIR.Service.Test
{
    public class ResultadoAcumuladoTest
    {
        [Fact]
        public void Incluir_Resultado_Inicial()
        {
            var context = ConfiguracaoTeste.ObterContexto();
            var service = new ResultadoService(context);

            var resultado = new ResultadoAcumulado();
            resultado.DataResultado = new DateTime(2015, 1, 2);
            resultado.Mercado = (char)Mercado.Acoes;
            resultado.Usuario = context.Usuario.First(p => p.Id == 1);

            service.IncluirAcumulado(resultado);

        }
    }
}
