using LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands;
using System.Linq;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar
{
    public class AtualizarCategoriaCommandTests : IClassFixture<AtualizarCategoriaCommandTestsFixture>
    {
        private readonly AtualizarCategoriaCommandTestsFixture _atualizarCategoriaCommandTestsFixture;

        public AtualizarCategoriaCommandTests(AtualizarCategoriaCommandTestsFixture atualizarCategoriaCommandTestsFixture)
        {
            _atualizarCategoriaCommandTestsFixture = atualizarCategoriaCommandTestsFixture;
        }

        [Fact(DisplayName = "Atualizar categoria command válido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria commands")]
        public void AtualizarCategoriaCommand_CommandValido_DevePassarNaValidacao()
        {
            // Arrange
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandValido();

            // Act
            var resultado = command.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Atualizar categoria commands")]
        public void AtualizarCategoriaCommand_CommandComNomeInvalido_NaoDevePassarNaValidacao(string nome)
        {
            // Arrange
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = command.EhValido();

            // Assert
            Assert.False(resultado);
        }

        [Fact(DisplayName = "Nome com a quantidade de caracteres acima do permitido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria commands")]
        public void AtualizarCategoriaCommand_NomeComAQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido();

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AtualizarCategoriaCommandValidation.MSG_ERRO_NOME_MAX_CARACTERES_NOME, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("0")]
        [Trait("Categoria", "Cadastro - Atualizar categoria commands")]
        public void AtualizarCategoriaCommand_CodigoInvalido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AtualizarCategoriaCommandValidation.MSG_ERRO_CODIGO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("1000")]
        [InlineData("0000")]
        [Trait("Categoria", "Cadastro - Atualizar categoria commands")]
        public void AtualizarCategoriaCommand_CodigoComQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _atualizarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AtualizarCategoriaCommandValidation.MSG_ERRO_CODIGO_MAX_CARACTERES_CODIGO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}