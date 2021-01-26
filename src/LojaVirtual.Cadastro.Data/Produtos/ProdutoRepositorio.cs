using LojaVirtual.Cadastro.Domain.Produtos.Interfaces;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.Data;
using System;

namespace LojaVirtual.Cadastro.Data.Produtos
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}