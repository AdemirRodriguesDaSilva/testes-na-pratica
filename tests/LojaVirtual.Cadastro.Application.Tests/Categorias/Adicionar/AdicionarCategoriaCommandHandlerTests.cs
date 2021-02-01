using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.Comunicacao;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Adicionar
{
    public class AdicionarCategoriaCommandHandlerTests : IClassFixture<AdicionarCategoriaCommandTestsFixture>
    {
        private readonly AdicionarCategoriaCommandTestsFixture _adicionarCategoriaCommandTestsFixture;
        private readonly AutoMocker _mocker;
        private readonly AdicionarCategoriaCommandHandler _adicionarCategoriaCommandHandler;

        public AdicionarCategoriaCommandHandlerTests(AdicionarCategoriaCommandTestsFixture adicionarCategoriaCommandTestsFixture)
        {
            _adicionarCategoriaCommandTestsFixture = adicionarCategoriaCommandTestsFixture;
            _mocker = new AutoMocker();
            _adicionarCategoriaCommandHandler = _mocker.CreateInstance<AdicionarCategoriaCommandHandler>();
        }

        [Fact(DisplayName = "Adicinar nova categoria com sucesso")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_NovaCategoria_DeveExecutarComSucesso()
        {
            // Arrange
            var command = _adicionarCategoriaCommandTestsFixture.GerarCommandValido();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.Never);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComNomeInvalido_DeveRetornarFalsoENaoExecutarOMetodoAdicionarENaoFazerCommit(string nome)
        {
            // Arrange
            var command = _adicionarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nome);

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }

        [Fact(DisplayName = "Nome com a quantidade de caracteres acima do permitido")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_NomeComAQuantidadeDeCaracteresAcimaDoPermitido_DeveRetornarFalsoENaoExecutarOMetodoAdicionarENaoFazerCommit()
        {
            // Arrange
            var command = _adicionarCategoriaCommandTestsFixture.GerarCommandComQuantidadeDeCaracteresDoNomeAcimaDoPermitido();

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComCodigoInvalido_DeveRetornarFalsoENaoExecutarOMetodoAdicionarENaoFazerCommit(string codigo)
        {
            // Arrange
            var command = _adicionarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }

        [Theory]
        [InlineData("1000")]
        [InlineData("0000")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CodigoComAQuantidadeDeCaracteresAcimaDoPermitido_DeveRetornarFalsoENaoExecutarOMetodoAdicionarENaoFazerCommit(string codigo)
        {
            // Arrange
            var command = _adicionarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }

        [Fact(DisplayName = "Adicionar categoria com o Nome já existente")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComNomeJaExistente_DeveLancarExcecaoENaoExecutarOMetodoAdicionarENaoFazerCommit()
        {
            // Arrange
            var nomeCategoria = "Esporte";
            var command1 = _adicionarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nomeCategoria);
            var command2 = _adicionarCategoriaCommandTestsFixture.GerarCommandComNomeInformado(nomeCategoria);

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(nomeCategoria, command1.Codigo)).Returns(Task.FromResult((Categoria)null));

            await _adicionarCategoriaCommandHandler.Handle(command1, CancellationToken.None);
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(nomeCategoria, command2.Codigo)).Returns(Task.FromResult(new Categoria(nomeCategoria, command1.Codigo, true)));

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command2, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.Once);
        }

        [Fact(DisplayName = "Adicionar categoria com o Codigo já existente")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComCodigoJaExistente_DeveLancarExcecaoENaoExecutarOMetodoAdicionarENaoFazerCommit()
        {
            // Arrange
            var codigo = "001";
            var command1 = _adicionarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);
            var command2 = _adicionarCategoriaCommandTestsFixture.GerarCommandComCodigoInformado(codigo);

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(command1.Nome, codigo)).Returns(Task.FromResult((Categoria)null));

            await _adicionarCategoriaCommandHandler.Handle(command1, CancellationToken.None);
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(command2.Nome, codigo)).Returns(Task.FromResult(new Categoria(command1.Nome, command1.Codigo, true)));

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command2, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.Once);
        }

        [Fact(DisplayName = "Adicionar categoria com o Nome e Codigo já existentes")]
        [Trait("Categoria", "Cadastro - Adicionar categoria command handler")]
        public async Task AdicionarCategoria_CategoriaComNomeECodigoJaExistentes_DeveLancarExcecaoENaoExecutarOMetodoAdicionarENaoFazerCommit()
        {
            // Arrange
            var command1 = _adicionarCategoriaCommandTestsFixture.GerarCommandValido();
            var command2 = command1;

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(command1.Nome, command1.Codigo)).Returns(Task.FromResult((Categoria)null));

            await _adicionarCategoriaCommandHandler.Handle(command1, CancellationToken.None);
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(command2.Nome, command2.Codigo)).Returns(Task.FromResult(new Categoria(command1.Nome, command1.Codigo, true)));

            // Act
            var resultado = await _adicionarCategoriaCommandHandler.Handle(command2, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Adicionar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.Exactly(2));
        }
    }
}