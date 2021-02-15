using Bogus;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.Tests;

namespace LojaVirtual.Cadastro.Domain.Tests.Produtos.Fixtures
{
    public class ProdutoTestsFixture : Fixture
    {
        private readonly DimensaoTestsFixture _dimensaoTestsFixture;

        public ProdutoTestsFixture()
        {
            _dimensaoTestsFixture = new DimensaoTestsFixture();
        }

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
                     _dimensaoTestsFixture.GerarDimensaoValida()));

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
                    _dimensaoTestsFixture.GerarDimensaoInvalida()));

            return produto;
        }
    }
}