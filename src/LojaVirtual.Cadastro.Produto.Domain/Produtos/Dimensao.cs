using LojaVirtual.Core.DomainObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Cadastro.Produtos
{
    public class Dimensao
    {
        [NotMapped]
        public static int ALTURA_MINIMA => 1;
        [NotMapped]
        public static int ALTURA_MAXIMA => 20;
        [NotMapped]
        public static int LARGURA_MINIMA => 1;
        [NotMapped]
        public static int LARGURA_MAXIMA => 15;
        [NotMapped]
        public static int PROFUNDIDADE_MINIMA => 1;
        [NotMapped]
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

        public void AlterarAltura(decimal altura)
        {
            Altura = altura;
            Validar();
        }

        public void AlterarLargura(decimal largura)
        {
            Largura = largura;
            Validar();
        }

        public void AlterarProfundidade(decimal profundidade)
        {
            Profundidade = profundidade;
            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarMinimoMaximo(Altura, ALTURA_MINIMA, ALTURA_MAXIMA, $"A Altura do produdo deve ser no mínimo {ALTURA_MINIMA} e no máximo {ALTURA_MAXIMA}");
            Validacoes.ValidarMinimoMaximo(Largura, LARGURA_MINIMA, LARGURA_MAXIMA, $"A Altura do produdo deve ser no mínimo {LARGURA_MINIMA} e no máximo {LARGURA_MAXIMA}");
            Validacoes.ValidarMinimoMaximo(Profundidade, PROFUNDIDADE_MINIMA, PROFUNDIDADE_MAXIMA, $"A Altura do produdo deve ser no mínimo {PROFUNDIDADE_MINIMA} e no máximo {PROFUNDIDADE_MAXIMA}");
        }
    }
}