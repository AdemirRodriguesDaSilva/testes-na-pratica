using AutoMapper;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;

namespace LojaVirtual.Cadastro.Categorias.Application.AutoMapper
{
    public class ViewModelParaDominioMapeamentoProfile : Profile
    {
        public ViewModelParaDominioMapeamentoProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>()
                .ConvertUsing(c => new Categoria(c.Nome, c.Codigo, c.Ativo));
        }
    }
}