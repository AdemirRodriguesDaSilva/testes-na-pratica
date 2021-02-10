using LojaVirtual.Cadastro.Domain.Tests.Produtos.Fixtures;
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

        //[Fact(DisplayName = "Novo Produto válido")]
        //[Trait("Categoria", "Cadastro - Produto")]
        //public void Produto_ProdutoValido_DeveEstarValido()
        //{
        //    // Arrange
        //    var produto = _produtoTestsFixture.GerarProdutoValido();

        //    // Act
        //    //var resultado = produto.EhValido();
        //    var resultado = produto.EhValido;

        //    // Assert
        //    Assert.True(resultado);
        //    Assert.Equal(0, produto.ValidationResult.Errors.Count);
        //}

        //[Fact(DisplayName = "Novo Produto inválido")]
        //[Trait("Categoria", "Cadastro - Produto")]
        //public void Produto_ProdutoInvalido_DeveEstarInvalido()
        //{
        //    // Arrange && Act && Assert
        //    Assert.Throws<ExcecaoDoDominio>(() => _produtoTestsFixture.GerarProdutoInvalido());
        //}

        //[Theory]
        //[InlineData("Novo nome do produto")]
        //[InlineData(" Novo nome do produto")]
        //[InlineData("  Novo nome do produto  ")]
        //[Trait("Categoria", "Cadastro - Produto")]
        //public void AlterarNome_NomeValido_NaoDeveLancarExcecao(string nome)
        //{
        //    // Arrange
        //    var produto = _produtoTestsFixture.GerarProdutoValido();

        //    // Act
        //    produto.AlterarNome(nome);

        //    // Assert
        //    Assert.True(produto.EhValido);
        //    Assert.Equal(nome, produto.Nome);
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData(" ")]
        //[InlineData(null)]
        //[Trait("Categoria", "Cadastro - Produto")]
        //public void AlterarNome_NomeInvalido_DeveLancarExcecao(string nome)
        //{
        //    // Arrange
        //    var produto = _produtoTestsFixture.GerarProdutoValido();

        //    // Assert && Act
        //    Assert.Throws<ExcecaoDoDominio>(() => produto.AlterarNome(nome));
        //    Assert.NotEqual(nome, produto.Nome);
        //}

        //[Fact(DisplayName = "Nome com caracteres acima do permitdo")]
        //[Trait("Categoria", "Cadastro - Produto")]
        //public void AlterarNome_NomeComCaracteresAcimaDoPermitido_DeveLancarExcecao()
        //{
        //    // Arrange
        //    var produto = _produtoTestsFixture.GerarProdutoValido();
        //    string nomeComCaracteresAcimaDoPermitido = produto.Nome.PadRight(251, 'a');
        //    var count = nomeComCaracteresAcimaDoPermitido.Length;
        //    // Act
        //    produto.AlterarNome(nomeComCaracteresAcimaDoPermitido);
            
        //    // Assert
        //    Assert.NotEqual(nomeComCaracteresAcimaDoPermitido, produto.Nome);
        //    Assert.Contains(ProdutoValidacao.MSG_ERRO_NOME_COM_QTD_CARACTERES_ACIMA_DO_PERMITIDO, produto.ValidationResult.Errors.Select(e => e.ErrorMessage));
        //}
    }
}