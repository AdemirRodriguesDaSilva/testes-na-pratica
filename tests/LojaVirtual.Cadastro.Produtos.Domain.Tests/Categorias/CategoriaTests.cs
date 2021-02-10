using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Tests.Categorias.Fixtures;
using LojaVirtual.Core.DomainObject;
using Xunit;

namespace LojaVirtual.Cadastro.Domain.Tests.Categorias
{
    public class CategoriaTests : IClassFixture<CategoriaTestsFixture>
    {
        private readonly CategoriaTestsFixture _categoriaTestsFixture;

        public CategoriaTests(CategoriaTestsFixture categoriaTestsFixture)
        {
            _categoriaTestsFixture = categoriaTestsFixture;
        }

        [Fact(DisplayName = "Validar categoria válida")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void Validar_CategoriaValida_NaoDeveRetornarErro()
        {
            // Arrange && Act && Assert
            Assert.IsType<Categoria>(_categoriaTestsFixture.GerarCategoriaValida());
        }

        [Fact(DisplayName = "Validar categoria inválida")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void Validar_CategoriaValida_DeveRetornarErro()
        {
            // Arrange && Act && Assert
            Assert.Throws<ExcecaoDoDominio>(() => _categoriaTestsFixture.GerarCategoriaInvalida());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void AlterarNome_NomeInvalido_NaoDeveAlterarNomeEDeveLancarErro(string nome)
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act && Assert
            Assert.Throws<ExcecaoDoDominio>(() => categoria.AlterarNome(nome));
            Assert.NotEqual(nome, categoria.Nome);
        }

        [Theory]
        [InlineData("Novo nome")]
        [InlineData("   Novo nome")]
        [InlineData("Novo nome    ")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void AlterarNome_NomeValido_DeveAlterarNomeENaoDeveLancarErro(string nome)
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act
            categoria.AlterarNome(nome);

            // Assert
            Assert.Equal(nome, categoria.Nome);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void AlterarCodigo_CodigoInvalido_DeveRetornarExcecao(string codigo)
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act & Assert
            Assert.Throws<ExcecaoDoDominio>(() => categoria.AlterarCodigo(codigo));
        }

        [Theory]
        [InlineData("001")]
        [InlineData("020")]
        [InlineData("100")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void AlterarCodigo_CodigoValido_DeveAlterarCodigo(string codigo)
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act
            categoria.AlterarCodigo(codigo);

            // Assert
            Assert.Equal(categoria.Codigo, codigo);
        }

        [Fact(DisplayName = "Ativar categoria")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void Ativar_CategoriaInvativo_DeveAlterarColunaAtivoParaTrue()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act
            categoria.Ativar();

            // Assert
            Assert.True(categoria.Ativo);
        }

        [Fact(DisplayName = "Inativar categoria")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void Inativar_CategoriaAtivo_DeveAlterarColunaAtivoParaFalse()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();

            // Act
            categoria.Inativar();

            // Assert
            Assert.False(categoria.Ativo);
        }

        [Fact(DisplayName = "Alterar categoria - Campos válidos")]
        [Trait("Categoria", "Cadastro Categoria")]
        public void Alterar_CamposValidos_DeveAlterarTodosOsCamposInformados()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();
            string novoNome = "Novo Nome";
            string novoCodigo = "099";
            bool NovoAtivo = false;

            // Act
            categoria.Alterar(novoNome, novoCodigo, NovoAtivo);

            // Assert
            Assert.Equal(categoria.Nome, novoNome);
            Assert.Equal(categoria.Codigo, novoCodigo);
            Assert.Equal(categoria.Ativo, NovoAtivo);
        }
    }
}