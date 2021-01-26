using LojaVirtual.Cadastro.Domain.Categorias.Factorys;
using LojaVirtual.Core.DomainObject;
using Xunit;

namespace LojaVirtual.Cadastro.Domain.Tests.Categorias
{
    public class CategoriaTests
    {
        private readonly CategoriaFactory _categoriaFactory;

        public CategoriaTests()
        {
            _categoriaFactory = new CategoriaFactory();
        }

        [Fact(DisplayName = "Validar categoria válida")]
        [Trait("Categoria", "Validar")]
        public void EhValido_CategoriaValida_NaoDeveRetornarErro()
        {
            // Arrange
            var categoria = _categoriaFactory.GerarCategoriaValida();

            // Act
            var resultado = categoria.EhValido();

            // Assert
            Assert.True(resultado);
            Assert.Equal(0, categoria.ValidationResult.Errors.Count);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Categoria", "Validar")]
        public void AlterarNome_NomeInvalido_DeveRetornarExcecao(string nome)
        {
            // Arrange
            var categoria = _categoriaFactory.GerarCategoriaValida();

            // Act & Assert
            Assert.Throws<ExcecaoDoDominio>(() => categoria.AlterarNome(nome));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Categoria", "Validar")]
        public void AlterarCodigo_CodigoInvalido_DeveRetornarExcecao(string codigo)
        {
            // Arrange
            var categoria = _categoriaFactory.GerarCategoriaValida();

            // Act & Assert
            Assert.Throws<ExcecaoDoDominio>(() => categoria.AlterarCodigo(codigo));
        }

        [Fact(DisplayName = "Ativar categoria")]
        [Trait("Categoria", "Ativar")]
        public void Ativar_CategoriaInvativo_DeveAlterarColunaAtivoParaTrue()
        {
            // Arrange
            var categoria = _categoriaFactory.GerarCategoriaValida();

            // Act
            categoria.Ativar();

            // Assert
            Assert.True(categoria.Ativo);
        }

        [Fact(DisplayName = "Inativar categoria")]
        [Trait("Categoria", "Inativar")]
        public void Inativar_CategoriaAtivo_DeveAlterarColunaAtivoParaFalse()
        {
            // Arrange
            var categoria = _categoriaFactory.GerarCategoriaValida();

            // Act
            categoria.Inativar();

            // Assert
            Assert.False(categoria.Ativo);
        }
    }
}