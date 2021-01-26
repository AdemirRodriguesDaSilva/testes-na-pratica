using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos
{
    public interface ICategoriaAplicacaoServicoObter : IDisposable
    {
        Task<CategoriaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<CategoriaViewModel>> ObterTodos();
    }
}