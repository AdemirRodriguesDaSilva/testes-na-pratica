using LojaVirtual.Cadastro.Domain.Categorias;
using LojaVirtual.Cadastro.Produtos;
using LojaVirtual.Core.DomainObject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Cadastro.Categorias
{
    public class Categoria : Entidade, IEntidadeRaizDeAgregacao
    {
        public static int MAX_CARACTERES_NOME = 250;
        public static int MAX_CARACTERES_CODIGO = 3;

        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public bool Ativo { get; private set; }
        [NotMapped]
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

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "Por favor, certifique-se de ter informado o Nome da categoria");
            Validacoes.ValidarSeVazio(Codigo, "Por favor, certifique-se de ter informado o Codigo da categoria");
            Validacoes.ValidarSeEhTrueOuFalse(Ativo, "Por favor, certifique-se de ter informado o Ativo da categoria");
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, "Por favor, certifique-se de ter informado o Nome da categoria");
            Nome = nome;
        }

        public void AlterarCodigo(string codigo)
        {
            Validacoes.ValidarSeVazio(codigo, "Por favor, certifique-se de ter informado o Codigo da categoria");
            Codigo = codigo;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido() => new CategoriaValidacao().Validate(this).IsValid;
    }
}