using Bogus;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.Tests;

namespace LojaVirtual.Cadastro.Domain.Tests.Produtos.Fixtures
{
    public class DimensaoTestsFixture : Fixture
    {
        public Dimensao GerarDimensaoValida()
        {
            var dimensao = new Faker<Dimensao>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(d => new Dimensao(
                                         d.Random.Decimal(Dimensao.ALTURA_MINIMA, Dimensao.ALTURA_MAXIMA),
                                         d.Random.Decimal(Dimensao.LARGURA_MINIMA, Dimensao.LARGURA_MAXIMA),
                                         d.Random.Decimal(Dimensao.PROFUNDIDADE_MINIMA, Dimensao.PROFUNDIDADE_MAXIMA)));

            return dimensao;
        }

        public Dimensao GerarDimensaoInvalida()
        {
            var dimensao = new Faker<Dimensao>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(d => new Dimensao(
                                         d.Random.Decimal(Dimensao.ALTURA_MINIMA + 1, Dimensao.ALTURA_MAXIMA),
                                         d.Random.Decimal(Dimensao.LARGURA_MINIMA, Dimensao.LARGURA_MAXIMA + 1),
                                         d.Random.Decimal(Dimensao.PROFUNDIDADE_MINIMA + 2, Dimensao.PROFUNDIDADE_MAXIMA)));

            return dimensao;
        }
    }
}