using LojaVirtual.Cadastro.Produtos;

namespace LojaVirtual.Cadastro.Domain.Produtos.Mensagens
{
    public class DimensaoMensagemErro
    {
        public static string ALTURA => $"A Altura do produdo deve ser no mínimo {Dimensao.ALTURA_MINIMA} e no máximo {Dimensao.ALTURA_MAXIMA}";
        public static string LARGURA => $"A Altura do produdo deve ser no mínimo {Dimensao.LARGURA_MINIMA} e no máximo {Dimensao.LARGURA_MAXIMA}";
        public static string PROFUNDIDADE => $"A Altura do produdo deve ser no mínimo {Dimensao.PROFUNDIDADE_MINIMA} e no máximo {Dimensao.PROFUNDIDADE_MAXIMA}";
    }
}