using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Core.Data;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Domain.Categorias.Repositorios
{
    public interface ICategoriaRepositorio : ICadastrarRepositorio<Categoria>, IObterRepositorio<Categoria>
    {
        Task<Categoria> Obter(string nome, string codigo);
    }
}