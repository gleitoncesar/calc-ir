using CalcIR.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace CalcIR.Service.Test
{
    public class ResultadoAcumuladoTest
    {
        [Fact]
        public void Incluir_Resultado_Inicial()
        {
            var service = new ResultadoService(ConfiguracaoTeste.ObterContexto());

            var resultado = new ResultadoAcumulado();
            resultado.DataResultado = new DateTime(2015, 1, 2);
            resultado.Mercado = (char)Mercado.Acoes;
            resultado.Usuario = new Usuario() { Id = 1 };

            service.IncluirAcumulado(resultado);

        }
    }
}
