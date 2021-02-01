using Bogus;
using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using System;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Adicionar
{
    public abstract class CategoriaCommandTestsFixture : IDisposable
    {
        private string IDIOMA_PORTUGUES_BRASIL => "pt_BR";

        public AdicionarCategoriaCommand GerarCommandValido()
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    c.Commerce.Categories(1)[0],
                    c.Random.Number(100).ToString()));

            return command;
        }

        public AdicionarCategoriaCommand GerarCommandComNomeInformado(string nome)
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    nome,
                    c.Random.Number(100).ToString()));

            return command;
        }

        public AdicionarCategoriaCommand GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido()
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    c.Random.String(251),
                    c.Random.Number(100).ToString()));

            return command;
        }

        public AdicionarCategoriaCommand GerarCommandComCodigoInformado(string codigo)
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    c.Commerce.Categories(1)[0],
                    codigo));

            return command;
        }

        public void Dispose()
        {
        }
    }
}