using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Handlers;
using LojaVirtual.Cadastro.Application.Categorias.Atualizar.Handler;
using LojaVirtual.Cadastro.Application.Tests.Categorias.Adicionar.Fixtures;
using LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar.Fixtures;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Cadastro.Domain.Tests.Categorias.Fixtures;
using LojaVirtual.Core.Comunicacao.Mediator;
using LojaVirtual.Core.Messages.Notificacao;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LojaVirtual.Cadastro.Application.Tests.Categorias.Atualizar.Handlers
{
    public class AtualizarCategoriaCommandHandlerTests : IClassFixture<AtualizarCategoriaCommandTestsFixture>
    {        
        private readonly AutoMocker _mocker;
     
        private readonly AtualizarCategoriaCommandTestsFixture _atualizarCategoriaCommandTestsFixture;
        private readonly CategoriaTestsFixture _categoriaTestsFixture;
        private readonly AdicionarCategoriaCommandTestsFixture _adicionarCategoriaCommandTestsFixture;
        
        private readonly AtualizarCategoriaCommandHandler _atualizarCategoriaCommandHandler;
        private readonly AdicionarCategoriaCommandHandler _adicionarCategoriaCommandHandler;

        public AtualizarCategoriaCommandHandlerTests(AtualizarCategoriaCommandTestsFixture atualizarCategoriaCommandTestsFixture)
        {
            _atualizarCategoriaCommandTestsFixture = atualizarCategoriaCommandTestsFixture;

            _mocker = new AutoMocker();

            _categoriaTestsFixture = _mocker.CreateInstance<CategoriaTestsFixture>();
            _adicionarCategoriaCommandTestsFixture = _mocker.CreateInstance<AdicionarCategoriaCommandTestsFixture>();

            _atualizarCategoriaCommandHandler = _mocker.CreateInstance<AtualizarCategoriaCommandHandler>();
            _adicionarCategoriaCommandHandler = _mocker.CreateInstance<AdicionarCategoriaCommandHandler>();
        }

        [Fact(DisplayName = "Atualizar categoria command válido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command handler")]
        public async Task AtualizarCategoria_CommandValido_DeveExecutarComSucesso()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Adicionar(categoria));

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.ObterPorId(categoria.Id)).Returns(Task.FromResult(categoria));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandValido(categoria.Id);

            // Act
            var resultado = await _atualizarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Atualizar(It.IsAny<Categoria>()), Times.Once);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.Never);
        }

        [Fact(DisplayName = "Atualizar categoria command inválido")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command handler")]
        public async Task AtualizarCategoria_CommandInvalido_NaoDeveAlterarEDevePublicarNotificacao()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Adicionar(categoria));

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.ObterPorId(categoria.Id)).Returns(Task.FromResult(categoria));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            var command = _atualizarCategoriaCommandTestsFixture.GerarCommandInvalido(categoria.Id);

            // Act
            var resultado = await _atualizarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Atualizar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }

        [Fact(DisplayName = "Atualizar categoria nome já existente")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command handler")]
        public async Task AtualizarCategoria_NomeJaExistente_NaoDeveAlterarEDevePublicarNotificacao()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Adicionar(categoria));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.ObterPorId(categoria.Id)).Returns(Task.FromResult(categoria));
            
            var command = _atualizarCategoriaCommandTestsFixture.GerarCommand(categoria.Id, categoria.Nome, "008", categoria.Ativo);
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(categoria.Nome, command.Codigo)).Returns(Task.FromResult(categoria));

            // Act
            var resultado = await _atualizarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Atualizar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.AtLeastOnce);
        }

        [Fact(DisplayName = "Atualizar categoria código já existente")]
        [Trait("Categoria", "Cadastro - Atualizar categoria command handler")]
        public async Task AtualizarCategoria_CodigoJaExistente_NaoDeveAlterarEDevePublicarNotificacao()
        {
            // Arrange
            var categoria = _categoriaTestsFixture.GerarCategoriaValida();
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Adicionar(categoria));
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.ObterPorId(categoria.Id)).Returns(Task.FromResult(categoria));

            var command = _atualizarCategoriaCommandTestsFixture.GerarCommand(categoria.Id, "Novo nome", categoria.Codigo, categoria.Ativo);
            _mocker.GetMock<ICategoriaRepositorio>().Setup(r => r.Obter(command.Nome, categoria.Codigo)).Returns(Task.FromResult(categoria));

            // Act
            var resultado = await _atualizarCategoriaCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.Atualizar(It.IsAny<Categoria>()), Times.Never);
            _mocker.GetMock<ICategoriaRepositorio>().Verify(r => r.UnitOfWork.Commit(), Times.Never);
            _mocker.GetMock<IMediatorHandler>().Verify(r => r.PublicarNotificacao(It.IsAny<DominioNotificacao>()), Times.AtLeastOnce);
        }
    }
}