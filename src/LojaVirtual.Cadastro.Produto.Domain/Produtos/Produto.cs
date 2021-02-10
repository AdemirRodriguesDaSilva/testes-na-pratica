using LojaVirtual.Cadastro.Categorias;
using LojaVirtual.Cadastro.Domain.Produtos.Mensagens;
using LojaVirtual.Core.DomainObject;
using System;

namespace LojaVirtual.Cadastro.Produtos
{
    public class Produto : Entidade, IEntidadeRaizDeAgregacao
    {
        public static int QUANTIDADE_MINIMA => 1;
        public static int QUANTIDADE_MAXIMA => 15;
        public static decimal VALOR_MINIMO => 1;
        public static decimal VALOR_MAXIMO => 1000000;

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

        public override void Validar()
        {
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, ProdutoMensagemErro.CATEGORIAID_INVALIDO);
            Validacoes.ValidarSeVazio(Nome, ProdutoMensagemErro.NOME_INVALIDO);
            Validacoes.ValidarSeVazio(Descricao, ProdutoMensagemErro.DESCRICAO_INVALIDA);
            Validacoes.ValidarSeVazio(Imagem, ProdutoMensagemErro.IMAGEM_INVALIDA);
            Validacoes.ValidarMinimoMaximo(Quantidade, QUANTIDADE_MINIMA, QUANTIDADE_MAXIMA, ProdutoMensagemErro.QUANTIDADE);
            Validacoes.ValidarMinimoMaximo(Valor, VALOR_MINIMO, VALOR_MAXIMO, ProdutoMensagemErro.VALOR);
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, ProdutoMensagemErro.NOME_INVALIDO);
            Nome = nome;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, ProdutoMensagemErro.DESCRICAO_INVALIDA);
            Descricao = descricao;
        }

        public void AlterarImagem(string imagem)
        {
            Validacoes.ValidarSeVazio(imagem, ProdutoMensagemErro.IMAGEM_INVALIDA);
            Imagem = imagem;
        }

        public void AlterarQuantidade(int quantidade)
        {
            Validacoes.ValidarMinimoMaximo(quantidade, QUANTIDADE_MINIMA, QUANTIDADE_MAXIMA, ProdutoMensagemErro.QUANTIDADE);
            Quantidade = quantidade;
        }

        public void AlterarValor(decimal valor)
        {
            Validacoes.ValidarMinimoMaximo(valor, VALOR_MINIMO, VALOR_MAXIMO, ProdutoMensagemErro.VALOR);
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
    }
}