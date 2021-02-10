using Bogus;
using LojaVirtual.Cadastro.Categorias;
using System;

namespace LojaVirtual.Cadastro.Domain.Tests.Categorias
{
    public class CategoriaTestsFixture : IDisposable
    {
        private string IDIOMA_PORTUGUES_BRASIL => "pt_BR";

        public Categoria GerarCategoriaValida()
        {
            var categoria = new Faker<Categoria>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new Categoria(
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return categoria;
        }

        public Categoria GerarCategoria(string nome)
        {
            var categoria = new Faker<Categoria>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new Categoria(
                    nome,
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return categoria;
        }

        public Categoria GerarCategoriaInvalida()
        {
            var categoria = new Faker<Categoria>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new Categoria(
                    string.Empty,
                    c.Random.Number(1000, 2000).ToString(),
                    false));

            return categoria;
        }

        public void Dispose()
        {
        }
    }
}