using Bogus;
using LojaVirtual.Cadastro.Categorias;
using System;
using Xunit;

namespace LojaVirtual.Cadastro.Fixture.Tests.Categorias
{
    [CollectionDefinition(nameof(CategoriaCollection))]
    public class CategoriaCollection : ICollectionFixture<CategoriaTestsFixture>{ }
    public class CategoriaTestsFixture : IDisposable
    {
        private string IDIOMA_PORTUGUES_BRASIL => "pt_BR";

        public Categoria GerarCategoriaValida()
        {
            var categoria = new Faker<Categoria>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new Categoria(
                    c.Commerce.Categories(1)[0],
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return categoria;
        }

        public Categoria GerarCategoriaInvalida()
        {
            var categoria = new Categoria(
                    "",
                    "",
                    false);

            return categoria;
        }

        public void Dispose()
        {
        }
    }
}