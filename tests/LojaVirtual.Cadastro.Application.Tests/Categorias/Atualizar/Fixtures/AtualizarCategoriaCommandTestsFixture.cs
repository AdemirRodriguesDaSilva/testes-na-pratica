using Bogus;
using LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands;
using LojaVirtual.Core.Tests;
using System;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar.Fixtures
{
    public class AtualizarCategoriaCommandTestsFixture : Fixture
    {
        public AtualizarCategoriaCommand GerarCommand(Guid id, string nome, string codigo, bool ativo)
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    id,
                    nome,
                    codigo,
                    ativo));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandValido()
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    c.Random.Guid(),
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandValido(Guid id)
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    id,
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandInvalido(Guid id)
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    id,
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 251, 300),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandComIdInvalido()
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    Guid.Empty,
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandComNomeInformado(string nome)
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    c.Random.Guid(),
                    nome,
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido()
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    c.Random.Guid(),
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 251, 300),
                    c.Random.Number(100).ToString(),
                    c.Random.Bool()));

            return command;
        }

        public AtualizarCategoriaCommand GerarCommandComCodigoInformado(string codigo)
        {
            var command = new Faker<AtualizarCategoriaCommand>(IDIOMA_PORTUGUES_BRASIL)
                .CustomInstantiator(c => new AtualizarCategoriaCommand(
                    c.Random.Guid(),
                    c.Random.ClampString(c.Commerce.Categories(1)[0], 1, 250),
                    codigo,
                    c.Random.Bool()));

            return command;
        }
    }
}