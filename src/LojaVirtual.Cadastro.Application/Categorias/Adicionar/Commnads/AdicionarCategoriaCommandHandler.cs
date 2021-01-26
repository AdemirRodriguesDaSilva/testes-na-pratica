using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommandHandler : IRequestHandler<AdicionarCategoriaCommand, bool>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public AdicionarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<bool> Handle(AdicionarCategoriaCommand command, CancellationToken cancellationToken)
        {
            if (!command.ValidarCommand(command))
                return false;

            var categoria = new Categoria(command.Nome, command.Codigo, true);

            _categoriaRepositorio.Adicionar(categoria);

            return await _categoriaRepositorio.UnitOfWork.Commit();
        }
    }
}