using FluentValidation;
using LojaVirtual.Cadastro.Categorias;

namespace LojaVirtual.Cadastro.Domain.Categorias
{
    public class CategoriaValidacao : AbstractValidator<Categoria>
    {
        public CategoriaValidacao()
        {
            RuleFor(c => c.Nome)
                .NotNull()
                .MaximumLength(250)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter informado o Nome da categoria");

            RuleFor(c => c.Codigo)
                .NotNull()
                .MaximumLength(3)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter informado o Codigo da categoria");
        }
    }
}