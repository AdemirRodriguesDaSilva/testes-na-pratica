using FluentValidation;
using LojaVirtual.Cadastro.Produtos;

namespace LojaVirtual.Cadastro.Domain.Produtos.Validacoes
{
    public class DimensaoValidacao : AbstractValidator<Dimensao>
    {
        public DimensaoValidacao()
        {
            RuleFor(p => p.Altura)
               .LessThan(1).WithMessage("Por favor, certifique-se de ter informado a Altura");

            RuleFor(p => p.Largura)
               .LessThan(1).WithMessage("Por favor, certifique-se de ter informado a Largura");

            RuleFor(p => p.Profundidade)
               .LessThan(1).WithMessage("Por favor, certifique-se de ter informado a Profundidade");
        }
    }
}