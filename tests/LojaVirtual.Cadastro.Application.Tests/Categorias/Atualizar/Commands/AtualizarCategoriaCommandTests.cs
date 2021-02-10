using LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar.Fixtures;
using LojaVirtual.Cadastro.Domain.Categorias.Mensagens;
using System;
using System.Linq;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar.Commands
{
    public class AtualizarCategoriaCommandTests : IClassFixture<AtualizarCategoriaCommandTestsFixture>
    {
        private readonly AtualizarCategoriaCommandTestsFixture _atualizarCategoriaCommandTestsFixture;

        public AtualizarCategoriaCommandTests(AtualizarCategoriaCommandTestsFixture atualizarCategoriaCommandTestsFixture)
        {
            _atualizarCategoriaCommandTestsFixture = atualizarCategoriaCommandTestsFixture;
        }

        [Fact(DisplayName = "Atualizar categoria command válido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_CommandValido_DevePassarNaValidacao()
        {
            // Arrange
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandValido();

            // Act
            var resultado = command.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact(DisplayName = "Id inválido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_CommandComIdInvalido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandComIdInvalido();

            // Act
            var resultado = command.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(CategoriaMensagemErro.ID_INVALIDO, command.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_CommandComNomeInvalido_NaoDevePassarNaValidacao(string nome)
        {
            // Arrange
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = command.EhValido();

            // Assert
            Assert.False(resultado);
        }

        [Fact(DisplayName = "Nome com a quantidade de caracteres acima do permitido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_NomeComAQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido();

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(CategoriaMensagemErro.NOME_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("0")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_CodigoInvalido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(CategoriaMensagemErro.CODIGO_INVALIDO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("1000")]
        [InlineData("0000")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void EhValido_CodigoComQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(CategoriaMensagemErro.CODIGO_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Atualizar categoria command")]
        public void AlterarNome_NomeInvalido_NomeNaoPodeSerAlteradoEDeveLancarUmaExcecaoDeDomio(string nome)
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(CategoriaMensagemErro.NOME_INVALIDO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}