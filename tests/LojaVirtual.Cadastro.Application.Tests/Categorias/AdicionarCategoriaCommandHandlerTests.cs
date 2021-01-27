using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.DomainObjects;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias
{
    public class AdicionarCategoriaCommandHandlerTests : IClassFixture<CategoriaCommandTestsFixture>
    {
        private readonly CategoriaCommandTestsFixture _categoriaCommandTestsFixture;
        private readonly AutoMocker _mocker;
        private readonly AdicionarCategoriaCommandHandler _adicionarCategoriaCommandHandler;

        public AdicionarCategoriaCommandHandlerTests(CategoriaCommandTestsFixture categoriaCommandTestsFixture)
        {
            _categoriaCommandTestsFixture = categoriaCommandTestsFixture;
            _mocker = new AutoMocker();
            _adicionarCategoriaCommandHandler = _mocker.CreateInstance<AdicionarCategoriaCommandHandler>();
        }

        [Fact(DisplayName = "Adicinar nova categoria com sucesso")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_NovaCategoria_DeveExecutarComSucesso()
        {
            // Arrange
            var command = _categoriaCommandTestsFixture.GerarCommandValido();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Theory]
        //[InlineData("")]
        //[InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComNomeInvalido_DeveRetornarFalsoENaoExecutarOMetodoAdicionarENemFazerCommit(string nome)
        {
            // Arrange
            var command = _categoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }
    }
}