using FluentValidation;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommandValidation : AbstractValidator<AdicionarCategoriaCommand>
    {
        public AdicionarCategoriaCommandValidation()
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