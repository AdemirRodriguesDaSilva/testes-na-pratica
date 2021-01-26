using AutoMapper;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;

namespace LojaVirtual.Cadastro.Categorias.Application.AutoMapper
{
    public class DominioParaViewModelMapeamentoProfile : Profile
    {
        public DominioParaViewModelMapeamentoProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}