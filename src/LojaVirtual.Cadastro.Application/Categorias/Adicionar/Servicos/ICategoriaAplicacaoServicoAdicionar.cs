using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Servicos
{
    public interface ICategoriaAplicacaoServicoAdicionar : IDisposable
    {
        Task Adicionar(CategoriaViewModel categoriaViewModel);
    }
}