using LojaVirtual.Cadastro.Domain.Produtos.Mensagens;
using LojaVirtual.Core.DomainObject;

namespace LojaVirtual.Cadastro.Produtos
{
    public class Dimensao
    {
        public static int ALTURA_MINIMA => 1;
        public static int ALTURA_MAXIMA => 20;
        public static int LARGURA_MINIMA => 1;
        public static int LARGURA_MAXIMA => 15;
        public static int PROFUNDIDADE_MINIMA => 1;
        public static int PROFUNDIDADE_MAXIMA => 20;

        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensao(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarMinimoMaximo(Altura, ALTURA_MINIMA, ALTURA_MAXIMA, DimensaoMensagemErro.ALTURA);
            Validacoes.ValidarMinimoMaximo(Largura, LARGURA_MINIMA, LARGURA_MAXIMA, DimensaoMensagemErro.LARGURA);
            Validacoes.ValidarMinimoMaximo(Profundidade, PROFUNDIDADE_MINIMA, PROFUNDIDADE_MAXIMA, DimensaoMensagemErro.PROFUNDIDADE);
        }

        public void AlterarAltura(decimal altura)
        {
            Validacoes.ValidarMinimoMaximo(Altura, ALTURA_MINIMA, ALTURA_MAXIMA, DimensaoMensagemErro.ALTURA);
            Altura = altura;
        }

        public void AlterarLargura(decimal largura)
        {
            Validacoes.ValidarMinimoMaximo(Largura, LARGURA_MINIMA, LARGURA_MAXIMA, DimensaoMensagemErro.LARGURA);
            Largura = largura;
        }

        public void AlterarProfundidade(decimal profundidade)
        {
            Validacoes.ValidarMinimoMaximo(Profundidade, PROFUNDIDADE_MINIMA, PROFUNDIDADE_MAXIMA, DimensaoMensagemErro.PROFUNDIDADE);
            Profundidade = profundidade;
        }
    }
}