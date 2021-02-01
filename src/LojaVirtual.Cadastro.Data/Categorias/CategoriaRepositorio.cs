using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using LojaVirtual.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Data.Categorias
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly CadastroContext _cadastroContext;

        public CategoriaRepositorio(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public IUnitOfWork UnitOfWork => _cadastroContext;

        public void Adicionar(Categoria categoria)
        {
            _cadastroContext.Add(categoria);
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _cadastroContext.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _cadastroContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> Obter(string nome, string codigo)
        {
            return await _cadastroContext.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Nome.Trim() == nome.Trim() ||
                                                                                             c.Codigo.Trim() == codigo.Trim());
        }

        public void Dispose()
        {
            _cadastroContext?.Dispose();
        }
    }
}