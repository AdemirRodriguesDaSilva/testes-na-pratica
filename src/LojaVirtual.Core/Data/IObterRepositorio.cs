using LojaVirtual.Core.DomainObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Data
{
    public interface IObterRepositorio<T> : IRepositorio<T> where T : IEntidadeRaizDeAgregacao
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
    }
}