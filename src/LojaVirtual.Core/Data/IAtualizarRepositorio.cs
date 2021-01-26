using LojaVirtual.Core.DomainObject;

namespace LojaVirtual.Core.Data
{
    public interface IAtualizarRepositorio<T> : IRepositorio<T> where T : IEntidadeRaizDeAgregacao
    {
        void Atualizar(T entidade);
    }
}