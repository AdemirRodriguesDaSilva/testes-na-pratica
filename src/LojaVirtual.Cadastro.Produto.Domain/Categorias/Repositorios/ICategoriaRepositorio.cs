using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Core.Data;

namespace LojaVirtual.Cadastro.Domain.Categorias.Repositorios
{
    public interface ICategoriaRepositorio : ICadastrarRepositorio<Categoria>, IObterRepositorio<Categoria>
    {
    }
}