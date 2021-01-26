using FluentValidation;
using LojaVirtual.Cadastro.Produtos;
using System;

namespace LojaVirtual.Cadastro.Domain.Produtos.Validacoes
{
    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(p => p.CategoriaId)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty).WithMessage("Por favor, certifique-se de ter informado a Categoria do produto");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter informado o Nome");

            RuleFor(p => p.Descricao)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado a Descrição");

            RuleFor(p => p.Imagem)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado a Imagem");

            RuleFor(p => p.Quantidade)
               .GreaterThan(0).WithMessage("Por favor, certifique-se de ter informado a Quantidade");

            RuleFor(p => p.Valor)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado o Valor");

            RuleFor(p => p.Dimensao.Altura)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado a Altura do produto")
               .GreaterThanOrEqualTo(Dimensao.ALTURA_MINIMA).WithMessage($"A Altura do produto de ter no mínimo {Dimensao.ALTURA_MINIMA}")
               .LessThanOrEqualTo(Dimensao.ALTURA_MAXIMA).WithMessage($"A Altura do produto de ter no máximo {Dimensao.ALTURA_MAXIMA}");

            RuleFor(p => p.Dimensao.Largura)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado a Largura do produto")
               .GreaterThanOrEqualTo(Dimensao.LARGURA_MINIMA).WithMessage($"A Largura do produto de ter no mínimo {Dimensao.LARGURA_MINIMA}")
               .LessThanOrEqualTo(Dimensao.LARGURA_MAXIMA).WithMessage($"A Largura do produto de ter no máximo {Dimensao.LARGURA_MAXIMA}");

            RuleFor(p => p.Dimensao.Profundidade)
               .NotEmpty().WithMessage("Por favor, certifique-se de ter informado a Profundidade do produto")
               .GreaterThanOrEqualTo(Dimensao.PROFUNDIDADE_MINIMA).WithMessage($"A Profundidade do produto de ter no mínimo {Dimensao.PROFUNDIDADE_MINIMA}")
               .LessThanOrEqualTo(Dimensao.PROFUNDIDADE_MAXIMA).WithMessage($"A Profundidade do produto de ter no máximo {Dimensao.PROFUNDIDADE_MAXIMA}");
        }
    }
}