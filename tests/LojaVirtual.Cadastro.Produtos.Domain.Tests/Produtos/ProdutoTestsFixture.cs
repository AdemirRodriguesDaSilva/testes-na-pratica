using Bogus;
using LojaVirtual.Cadastro.Produtos;
using System;

namespace LojaVirtual.Cadastro.Domain.Tests.Produtos
{
    public class ProdutoTestsFixture : IDisposable
    {
        private string IDIOMA_PORTUGUES_BRASIL = "pt_BR";

        public Produto GerarProdutoValido()
        {
            var produto = new Faker<Produto>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(p => new Produto(
                    p.Random.Guid(),
                    p.Random.ClampString(p.Commerce.ProductName(), 1, 250),
                    p.Random.ClampString(p.Commerce.ProductDescription(), 1, 500),
                    p.Random.ClampString(p.System.FilePath(), 1, 250),
                    p.Random.Number(Produto.QUANTIDADE_MINIMA, Produto.QUANTIDADE_MAXIMA),
                    p.Random.Decimal(Produto.VALOR_MINIMO, Produto.VALOR_MAXIMO),
                    true,
                     new Dimensao(p.Random.Decimal(Dimensao.ALTURA_MINIMA, Dimensao.ALTURA_MAXIMA),
                                         p.Random.Decimal(Dimensao.LARGURA_MINIMA, Dimensao.LARGURA_MAXIMA),
                                         p.Random.Decimal(Dimensao.PROFUNDIDADE_MINIMA, Dimensao.PROFUNDIDADE_MAXIMA))
                    ));

            return produto;
        }

        public Produto GerarProdutoInvalido()
        {
            var produto = new Faker<Produto>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(p => new Produto(
                    p.Random.Guid(),
                    p.Random.ClampString(p.Commerce.ProductName(), 1, 250),
                    p.Random.ClampString(p.Commerce.ProductDescription(), 1, 550),
                    p.Random.ClampString(p.System.FilePath(), 1, 250),
                    p.Random.Number(Produto.QUANTIDADE_MINIMA, Produto.QUANTIDADE_MAXIMA + 1),
                    p.Random.Decimal(Produto.VALOR_MINIMO, Produto.VALOR_MAXIMO + 1),
                    true,
                    new Dimensao(p.Random.Decimal(Dimensao.ALTURA_MINIMA + 1, Dimensao.ALTURA_MAXIMA), 
                                         p.Random.Decimal(Dimensao.LARGURA_MINIMA, Dimensao.LARGURA_MAXIMA + 1), 
                                         p.Random.Decimal(Dimensao.PROFUNDIDADE_MINIMA, Dimensao.PROFUNDIDADE_MAXIMA))
                    ));

            return produto;
        }

        public void Dispose()
        {
        }
    }
}