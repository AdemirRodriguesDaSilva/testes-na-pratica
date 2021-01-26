using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Produtos.Validacoes;
using LojaVirtual.Core.DomainObject;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Cadastro.Produtos
{
    public class Produto : Entidade, IEntidadeRaizDeAgregacao
    {
        [NotMapped]
        public static int QUANTIDADE_MINIMA => 1;
        [NotMapped]
        public static int QUANTIDADE_MAXIMA => 15;
        [NotMapped]
        public static decimal VALOR_MINIMO => 1;
        [NotMapped]
        public static decimal VALOR_MAXIMO => 1000000;
        [NotMapped]
        public static string MENSAGEM_ERRO_CATEGORIAID => "Por favor, certifique-se de ter informado a Categoria do produto";
        [NotMapped]
        public static string MENSAGEM_ERRO_NOME => "Por favor, certifique-se de ter informado o Nome do produto";
        [NotMapped]
        public static string MENSAGEM_ERRO_DESCRICAO => "Por favor, certifique-se de ter informado a Descrição do produto";
        [NotMapped]
        public static string MENSAGEM_ERRO_IMAGEM => "Por favor, certifique-se de ter informado a Imagem do produto";
        [NotMapped]
        public static string MENSAGEM_ERRO_QUANTIDADE => $"A Quantidade do produdo deve conter no mínimo {QUANTIDADE_MINIMA} e no máximo {QUANTIDADE_MAXIMA}";
        [NotMapped]
        public static string MENSAGEM_ERRO_VALOR => $"O Valor do produdo deve custar no mínimo {VALOR_MINIMO} e no máximo {VALOR_MAXIMO}";

        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }
        public Categoria Categoria { get; private set; }
        public Dimensao Dimensao { get; private set; }

        protected Produto()
        {
        }

        public Produto(Guid categoriaId, string nome, string descricao, string imagem, int quantidade, decimal valor, bool ativo, Dimensao dimensao)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
            Quantidade = quantidade;
            Valor = valor;
            Ativo = ativo;
            Dimensao = dimensao;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, MENSAGEM_ERRO_CATEGORIAID);
            Validacoes.ValidarSeVazio(Nome, MENSAGEM_ERRO_NOME);
            Validacoes.ValidarSeVazio(Descricao, MENSAGEM_ERRO_DESCRICAO);
            Validacoes.ValidarSeVazio(Imagem, MENSAGEM_ERRO_IMAGEM);
            Validacoes.ValidarMinimoMaximo(Quantidade, QUANTIDADE_MINIMA, QUANTIDADE_MAXIMA, MENSAGEM_ERRO_QUANTIDADE);
            Validacoes.ValidarMinimoMaximo(Valor, VALOR_MINIMO, VALOR_MAXIMO, MENSAGEM_ERRO_VALOR);

        }

        //public void Adicionar(Produto produto)
        //{

        //}

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, MENSAGEM_ERRO_NOME);
            Nome = nome;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, MENSAGEM_ERRO_NOME);
            Descricao = descricao;
        }

        public void AlterarImagem(string imagem)
        {
            Validacoes.ValidarSeVazio(imagem, MENSAGEM_ERRO_NOME);
            Imagem = imagem;
        }

        public void AlterarQuantidade(int quantidade)
        {
            Validacoes.ValidarMinimoMaximo(quantidade, QUANTIDADE_MINIMA, QUANTIDADE_MAXIMA, MENSAGEM_ERRO_QUANTIDADE);
            Quantidade = quantidade;
        }

        public void AlterarValor(decimal valor)
        {
            Validacoes.ValidarMinimoMaximo(valor, VALOR_MINIMO, VALOR_MAXIMO, MENSAGEM_ERRO_VALOR);
            Valor = valor;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}