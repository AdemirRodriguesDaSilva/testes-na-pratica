using System;

namespace LojaVirtual.Core.Data
{
    public interface IRepositorio<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}