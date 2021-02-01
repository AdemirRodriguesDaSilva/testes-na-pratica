using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.Comunicacao;
using LojaVirtual.Core.DomainObjects;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommandHandler : IRequestHandler<AdicionarCategoriaCommand, bool>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMediator _mediator;
        private readonly IMediatorHandler _mediatorHandler;

        public AdicionarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio, IMediator mediator, IMediatorHandler mediatorHandler)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mediator = mediator;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AdicionarCategoriaCommand command, CancellationToken cancellationToken)
        {
            if (!command.ValidarCommand(command, _mediator))
                return false;

            var _categoria = _categoriaRepositorio.Obter(command.Nome, command.Codigo).Result;
            if (_categoria != null)
            {
                if (_categoria.Nome.Trim().Equals(command.Nome.Trim()))
                    await _mediatorHandler.PublicarNotificacao(new DominioNotificacao("Categoria", $"Já possui uma Categoria cadastrada com o Nome {command.Nome}"));
                if (_categoria.Codigo.Trim().Equals(command.Codigo.Trim()))
                    await _mediatorHandler.PublicarNotificacao(new DominioNotificacao("Categoria", $"Já possui uma Categoria cadastrada com o Codigo {command.Codigo}"));

                return false;
            }

            var categoria = new Categoria(command.Nome, command.Codigo, true);

            _categoriaRepositorio.Adicionar(categoria);

            return await _categoriaRepositorio.UnitOfWork.Commit();
        }
    }
}