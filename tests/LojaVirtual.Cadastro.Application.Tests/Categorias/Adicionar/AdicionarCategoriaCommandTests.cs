using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using System.Linq;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Adicionar
{
    public class AdicionarCategoriaCommandTests : IClassFixture<AdicionarCategoriaCommandTestsFixture>
    {
        private readonly AdicionarCategoriaCommandTestsFixture _categoriaCommandTestsFixture;

        public AdicionarCategoriaCommandTests(AdicionarCategoriaCommandTestsFixture categoriaCommandTestsFixture)
        {
            _categoriaCommandTestsFixture = categoriaCommandTestsFixture;
        }

        [Fact(DisplayName = "Adicionar categoria commnad válido")]
        [Trait("Categoria", "Cadastro - Adicionar categoria commands")]
        public void AdicionarCategoriaCommand_CommandValido_DevePassarNaValidacao()
        {
            // Arrange
            var comand = _categoriaCommandTestsFixture.GerarCommandValido();

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.True(resultado);
            Assert.Equal(0, comand.ValidationResult.Errors.Count);

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Adicionar categoria commands")]
        public void AdicionarCategoriaCommand_NomeInvalido_NaoDevePassarNaValidacao(string nome)
        {
            // Arrange
            var comand = _categoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AdicionarCategoriaCommandValidation.MSG_ERRO_NOME, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Nome com a quantidade de caracteres acima do permitido")]
        [Trait("Categoria", "Cadastro - Adicionar categoria commands")]
        public void AdicionarCategoriaCommand_NomeComAQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var comand = _categoriaCommandTestsFixture.GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido();

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AdicionarCategoriaCommandValidation.MSG_ERRO_NOME_MAX_CARACTERES_NOME, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("0")]
        [Trait("Categoria", "Cadastro - Adicionar categoria commands")]
        public void AdicionarCategoriaCommand_CodigoInvalido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _categoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AdicionarCategoriaCommandValidation.MSG_ERRO_CODIGO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Theory]
        [InlineData("1000")]
        [InlineData("0000")]
        [Trait("Categoria", "Cadastro - Adicionar categoria commands")]
        public void AdicionarCategoriaCommand_CodigoComQuantidadeDeCaracteresAcimaDoPermitido_NaoDevePassarNaValidacao(string codigo)
        {
            // Arrange
            var comand = _categoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = comand.EhValido();

            // Assert
            Assert.False(resultado);
            Assert.Contains(AdicionarCategoriaCommandValidation.MSG_ERRO_CODIGO_MAX_CARACTERES_CODIGO, comand.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}