using Bogus;
using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Core.Tests;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Adicionar.Fixtures
{
    public class AdicionarCategoriaCommandTestsFixture : Fixture
    {
        public AdicionarCategoriaCommand GerarCommandValido()
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
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
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 251, 300),
                    c.Random.Number(100).ToString()));

            return command;
        }

        public AdicionarCategoriaCommand GerarCommandComCodigoInformado(string codigo)
        {
            var command = new Faker<AdicionarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AdicionarCategoriaCommand(
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    codigo));

            return command;
        }
    }
}