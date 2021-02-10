using LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.Comunicacao.Mediator;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Atualizar.Handler
{
    public class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, bool>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMediator _mediator;
        private readonly IMediatorHandler _mediatorHandler;

        public AtualizarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio, IMediatorHandler mediatorHandler, IMediator mediator)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mediatorHandler = mediatorHandler;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AtualizarCategoriaCommand command, CancellationToken cancellationToken)
        {
            if (!command.ValidarCommand(command, _mediator))
                return false;

            var categoria = await _categoriaRepositorio.ObterPorId(command.Id);
            if(categoria == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DominioNotificacao("Categoria", "Categoria não encontrada"));
                return false;
            }

            categoria.Alterar(command.Nome, command.Codigo, command.Ativo);
            if (await CategoriaJaExistente(categoria))
                return false;

            _categoriaRepositorio.Atualizar(categoria);

            return await _categoriaRepositorio.UnitOfWork.Commit();
        }

        private async Task<bool> CategoriaJaExistente(Categoria categoria)
        {
            var _categoria = _categoriaRepositorio.Obter(categoria.Nome, categoria.Codigo).Result;
            if (_categoria == null)
                return false;

            if (_categoria.Nome.Trim().Equals(categoria.Nome.Trim()))
                await _mediatorHandler.PublicarNotificacao(new DominioNotificacao("Categoria", $"Já possui uma Categoria cadastrada com o Nome {categoria.Nome}"));
            if (_categoria.Codigo.Trim().Equals(categoria.Codigo.Trim()))
                await _mediatorHandler.PublicarNotificacao(new DominioNotificacao("Categoria", $"Já possui uma Categoria cadastrada com o Codigo {categoria.Codigo}"));

            return true;
        }
    }
}