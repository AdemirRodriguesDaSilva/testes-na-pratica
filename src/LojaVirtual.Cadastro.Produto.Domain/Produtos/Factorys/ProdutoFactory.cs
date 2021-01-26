using Bogus;
using LojaVirtual.Cadastro.Produtos;
using System;

namespace LojaVirtual.Cadastro.Domain.Produtos.Factorys
{
    public class ProdutoFactory : IDisposable
    {
        private const string IDIOMA_PORTUGUES_BRASIL = "pt_BR";

        public static Produto GerarProtudoInvativo()
        {
            var produto = GerarProdutoValido();
            produto.Inativar();
            return produto;
        }

        public static Produto GerarProtudoAtivo()
        {
            var produto = GerarProdutoValido();
            produto.Ativar();
            return produto;
        }

        public static Produto GerarProdutoValido()
        {
            //var genero = new Faker().PickRandom<Name.Gender>();
            //var email = new Faker().Internet.Email();
            //var produtoFacker = new Faker<Produto>();
            //produtoFacker.RuleFor(p => p.Nome, (n, p) => n.Commerce.ProductName());

            var produto = new Faker<Produto>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(f => new Produto(
                    Guid.NewGuid(),
                    f.Commerce.ProductName(),
                    f.Commerce.ProductDescription(),
                    f.System.FilePath(),
                    f.Random.Number(Produto.QUANTIDADE_MINIMA, Produto.QUANTIDADE_MAXIMA),
                    f.Random.Decimal(Produto.VALOR_MINIMO, Produto.VALOR_MAXIMO),
                    true,
                    new Dimensao(f.Random.Number(1, 20), f.Random.Number(1, 15), f.Random.Number(1, 20))));

            return produto;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
