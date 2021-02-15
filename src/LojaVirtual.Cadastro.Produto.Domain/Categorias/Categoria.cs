using LojaVirtual.Cadastro.Domain.Categorias.Mensagens;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.DomainObject;
using System.Collections.Generic;

namespace LojaVirtual.Cadastro.Categorias
{
    public class Categoria : Entidade, IEntidadeRaizDeAgregacao
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {
        }
        
        public Categoria(string nome, string codigo, bool ativo)
        {
            Nome = nome;
            Codigo = codigo;
            Ativo = ativo;

            Validar();
        }

        public override void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, CategoriaMensagemErro.NOME_INVALIDO);
            Validacoes.ValidarSeVazio(Codigo, CategoriaMensagemErro.CODIGO_INVALIDO);
            Validacoes.ValidarSeEhTrueOuFalse(Ativo, CategoriaMensagemErro.ATIVO);
        }

        public void Alterar(string nome, string codigo, bool ativo)
        {
            AlterarNome(nome);
            AlterarCodigo(codigo);
            if (ativo)
                Ativar();
            else
                Inativar();
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, CategoriaMensagemErro.NOME_INVALIDO);
            Nome = nome;
        }

        public void AlterarCodigo(string codigo)
        {
            Validacoes.ValidarSeVazio(codigo, CategoriaMensagemErro.CODIGO_INVALIDO);
            Codigo = codigo;
        }

        public void Ativar()
        {
            Validacoes.ValidarSeEhTrueOuFalse(Ativo, CategoriaMensagemErro.ATIVO);
            Ativo = true;
        }

        public void Inativar()
        {
            Validacoes.ValidarSeEhTrueOuFalse(Ativo, CategoriaMensagemErro.ATIVO);
            Ativo = false;
        }
    }
}