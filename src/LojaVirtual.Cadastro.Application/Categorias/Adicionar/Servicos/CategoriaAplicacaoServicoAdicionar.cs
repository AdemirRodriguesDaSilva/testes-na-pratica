using AutoMapper;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Servicos
{
    public class CategoriaAplicacaoServicoAdicionar : ICategoriaAplicacaoServicoAdicionar
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaAplicacaoServicoAdicionar(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task Adicionar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            _categoriaRepositorio.Adicionar(categoria);

            await _categoriaRepositorio.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _categoriaRepositorio?.Dispose();
        }
    }
}