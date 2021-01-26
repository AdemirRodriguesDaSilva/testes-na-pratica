using System.Threading.Tasks;

namespace LojaVirtual.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}