using LojaVirtual.Cadastro.Produtos;

namespace LojaVirtual.Cadastro.Domain.Produtos.Mensagens
{
    public class ProdutoMensagemErro
    {
        public static string CATEGORIAID_INVALIDO => "Por favor, certifique-se de ter informado a Categoria do produto";
        public static string NOME_INVALIDO => "Por favor, certifique-se de ter informado o Nome do produto";
        public static string DESCRICAO_INVALIDA => "Por favor, certifique-se de ter informado a Descrição do produto";
        public static string IMAGEM_INVALIDA => "Por favor, certifique-se de ter informado a Imagem do produto";
        public static string QUANTIDADE => $"A Quantidade do produdo deve conter no mínimo {Produto.QUANTIDADE_MINIMA} e no máximo {Produto.QUANTIDADE_MAXIMA}";
        public static string VALOR => $"O Valor do produdo deve custar no mínimo {Produto.VALOR_MINIMO} e no máximo {Produto.VALOR_MAXIMO}";
    }
}