using FluentValidation;
using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Domain.Categorias.Mensagens;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Validations
{
    public class AdicionarCategoriaCommandValidation : AbstractValidator<AdicionarCategoriaCommand>
    {
        public AdicionarCategoriaCommandValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(CategoriaMensagemErro.NOME_INVALIDO)
                .MaximumLength(250).WithMessage(CategoriaMensagemErro.NOME_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO);

            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage(CategoriaMensagemErro.CODIGO_INVALIDO)
                .NotEqual("0").WithMessage(CategoriaMensagemErro.CODIGO_INVALIDO)
                .MaximumLength(3).WithMessage(CategoriaMensagemErro.CODIGO_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO);

            RuleFor(c => c.Ativo)
                .Equal(true);
        }
    }
}