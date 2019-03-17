using CalcIR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CalcIR.Service.Test
{
    public class NotaCorretagemTest
    {
        [Fact]
        public void Nota_Corretagem_Compra()
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
            nota.Valorliquido = 10025.2m;
            nota.Usuario = context.Usuario.First(p => p.Id == 1);
            nota.ListaOperacao = new List<Operacao>()
            {
                new Operacao()
                {
                    DayTrade = false,
                    Papel = context.Papel.First(p => p.Id == 1),
                    Preco = 100,
                    Quantidade = 100,
                    ValorOperacao = 10000,
                    Tipo = (char) TipoOperacao.Compra
                }
            };

            service.Incluir(nota);
        }

        [Fact]
        public void Nota_Corretagem_Venda()
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
            nota.Valorliquido = 9974.8m;
            nota.Usuario = context.Usuario.First(p => p.Id == 1);
            nota.ListaOperacao = new List<Operacao>()
            {
                new Operacao()
                {
                    DayTrade = false,
                    Papel = context.Papel.First(p => p.Id == 1),
                    Preco = 100,
                    Quantidade = 100,
                    ValorOperacao = 10000,
                    Tipo = (char) TipoOperacao.Venda
                }
            };

            service.Incluir(nota);
        }

        [Fact]
        public void Nota_Corretagem_Compra_Venda()
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
            nota.Valorliquido = 25.2m;
            nota.Usuario = context.Usuario.First(p => p.Id == 1);
            nota.ListaOperacao = new List<Operacao>()
            {
                new Operacao()
                {
                    DayTrade = false,
                    Papel = context.Papel.First(p => p.Id == 1),
                    Preco = 100,
                    Quantidade = 100,
                    ValorOperacao = 10000,
                    Tipo = (char) TipoOperacao.Compra
                },
                new Operacao()
                {
                    DayTrade = false,
                    Papel = context.Papel.First(p => p.Id == 1),
                    Preco = 100,
                    Quantidade = 100,
                    ValorOperacao = 10000,
                    Tipo = (char) TipoOperacao.Venda
                }
            };

            service.Incluir(nota);
        }
    }
}