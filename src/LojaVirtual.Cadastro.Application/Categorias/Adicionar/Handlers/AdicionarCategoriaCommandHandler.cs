using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.Comunicacao.Mediator;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Handlers
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
            #region
            //if (!command.ValidarCommand(command, _mediator))
            //    return false;

            //if (await CategoriaJaExistente(command))
            //    return false;

            //var categoria = new Categoria(command.Nome, command.Codigo, true);
            ////if (!categoria.EhValido())
            //if (categoria.Invalido)
            //{
            //    await _mediatorHandler.PublicarNotificacoes(categoria.ValidationResult);
            //    return false;
            //}
            #endregion

            if (!command.ValidarCommand(command, _mediator))
                return false;

            var categoria = new Categoria(command.Nome, command.Codigo, true);
            if (await CategoriaJaExistente(categoria))
                return false;

            _categoriaRepositorio.Adicionar(categoria);
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