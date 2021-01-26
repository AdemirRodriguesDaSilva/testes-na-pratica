using LojaVirtual.Core.DomainObject;

namespace LojaVirtual.Core.Data
{
    public interface ICadastrarRepositorio<T> : IRepositorio<T> where T : IEntidadeRaizDeAgregacao
    {
        void Adicionar(T entidade);
    }
}