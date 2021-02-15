using LojaVirtual.Cadastro.Domain.Tests.Produtos.Fixtures;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.DomainObject;
using Xunit;

namespace LojaVirtual.Cadastro.Domain.Tests.Produtos
{
    public class ProdutoTests : IClassFixture<ProdutoTestsFixture>
    {
        private readonly ProdutoTestsFixture _produtoTestsFixture;

        public ProdutoTests(ProdutoTestsFixture produtoTestsFixture)
        {
            _produtoTestsFixture = produtoTestsFixture;
        }

        [Fact(DisplayName = "Novo Produto válido")]
        [Trait("Categoria", "Cadastro - Produto")]
        public void Produto_ProdutoValido_DeveEstarValido()
        {
            // Arrange && Act && Assert
            Assert.IsType<Produto>(_produtoTestsFixture.GerarProdutoValido());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Produto")]
        public void AlterarNome_NomeInvalido_DeveLancarExcecao(string nome)
        {
            // Arrange
            var produto = _produtoTestsFixture.GerarProdutoValido();
            
            // Assert && Act
            Assert.Throws<ExcecaoDoDominio>(() => produto.AlterarNome(nome));
            Assert.NotEqual(nome, produto.Nome);
        }
    }
}