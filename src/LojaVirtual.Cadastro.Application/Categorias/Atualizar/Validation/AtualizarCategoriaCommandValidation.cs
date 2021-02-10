using FluentValidation;
using LojaVirtual.Cadastro.Domain.Categorias.Mensagens;
using System;

namespace LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands
{
    public class AtualizarCategoriaCommandValidation : AbstractValidator<AtualizarCategoriaCommand>
    {
        public AtualizarCategoriaCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage(CategoriaMensagemErro.ID_INVALIDO)
                .NotEqual(Guid.Empty).WithMessage(CategoriaMensagemErro.ID_INVALIDO);

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(CategoriaMensagemErro.NOME_INVALIDO)
                .MaximumLength(250).WithMessage(CategoriaMensagemErro.NOME_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO);

            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage(CategoriaMensagemErro.CODIGO_INVALIDO)
                .NotEqual("0").WithMessage(CategoriaMensagemErro.CODIGO_INVALIDO)
                .MaximumLength(3).WithMessage(CategoriaMensagemErro.CODIGO_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO);

            RuleFor(c => c.Ativo)
                .NotNull().WithMessage(CategoriaMensagemErro.ATIVO);
        }
    }
}