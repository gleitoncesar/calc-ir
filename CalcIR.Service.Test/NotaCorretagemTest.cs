using CalcIR.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalcIR.Service.Test
{
    public class NotaCorretagemTest
    {
        [Fact]
        public void Incluir_Nota_Corretagem()
        {
            var context = ConfiguracaoTeste.ObterContexto();
            
            var service = new NotaCorretagemService(context);
            
            var nota = new NotaCorretagem();
            nota.DataLiquidacao = new DateTime(2019, 3, 15);
            nota.DataPregao = new DateTime(2019, 3, 13);
            nota.Numero = 1;
            nota.TaxaLiquidacao = 10.1m;
            nota.TaxaRegistro = 10.1m;
            nota.TotalBovespa = 5;
            nota.Valorliquido = 10000;
            nota.Usuario = new Usuario() { Id = 1 };
            nota.ListaOperacao = new List<Operacao>()
            {
                new Operacao()
                {
                    DayTrade = false,
                    Papel = new Papel()
                    {
                        Codigo = "XPTO4",
                        Nome = "Teste",
                        Mercado = (char)Mercado.Acoes
                    },
                    Preco = 100,
                    Quantidade = 100,
                    ValorOperacao = 10000,
                    Tipo = (char) TipoOperacao.Compra
                }
            };

            service.Incluir(nota);
        }
    }
}