using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommandHandler : IRequestHandler<AdicionarCategoriaCommand, bool>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMediator _mediator;

        public AdicionarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio, IMediator mediator)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AdicionarCategoriaCommand command, CancellationToken cancellationToken)
        {
            if (!command.ValidarCommand(command, _mediator))
                return false;

            var categoria = new Categoria(command.Nome, command.Codigo, true);

            _categoriaRepositorio.Adicionar(categoria);

            return await _categoriaRepositorio.UnitOfWork.Commit();
        }

        public Task Handle(AdicionarCategoriaCommand command, object cancelationToken)
        {
            throw new NotImplementedException();
        }
    }
}