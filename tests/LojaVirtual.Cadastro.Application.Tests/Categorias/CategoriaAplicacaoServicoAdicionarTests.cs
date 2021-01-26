using LojaVirtual.Cadastro.Domain.Categorias.Factorys;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias
{
    public class CategoriaAplicacaoServicoAdicionarTests
    {
        private readonly CategoriaFactory _categoriaFactory;
        
        public CategoriaAplicacaoServicoAdicionarTests()
        {
            _categoriaFactory = new CategoriaFactory();
        }

        //[Fact(DisplayName = "Adicionar Categoria com sucesso")]
        //[Trait("Categoria", "Servico adicionar categoria")]
        //public void CategoriaAplicacaoServicoAdicionar_Adicionar_DeveExecutarComSucesso()
        //{
        //    // Arrange
        //    var categoria = _categoriaFactory.GerarCategoriaValida();
        //    var categoriaRepositorio = new Mock<ICategoriaRepositorio>();
        //    var categoriaServico = new CategoriaAplicacaoServicoAdicionar(categoriaRepositorio.Object);

        //    // Act
        //    categoriaServico.Adicionar(categoria);

        //    // Assert
        //    Assert.True(categoria.EhValido());
        //    categoriaRepositorio.Verify(r => r.Adicionar(categoria), Times.Once);
        //}

        //[Fact(DisplayName = "Adicionar Categoria com falha")]
        //[Trait("Categoria", "Servico adicionar categoria")]
        //public void CategoriaAplicacaoServicoAdicionar_Adicionar_DeveFalharDevidoCategoriaInvalida()
        //{
        //    // Arrange
        //    var categoria = _categoriaFactory.GerarCategoriaInvalida();
        //    var categoriaRepositorio = new Mock<ICategoriaRepositorio>();
        //    var categoriaServico = new CategoriaAplicacaoServicoAdicionar(categoriaRepositorio.Object);

        //    // Act
        //    categoriaServico.Adicionar(categoria);

        //    //Assert
        //    Assert.False(categoria.EhValido());
        //    categoriaRepositorio.Verify(r => r.Adicionar(categoria), Times.Never);
        //}
    }
}