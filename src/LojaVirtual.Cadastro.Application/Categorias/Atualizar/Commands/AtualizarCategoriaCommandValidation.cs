using FluentValidation;
using LojaVirtual.Cadastro.Categorias;

namespace LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands
{
    public class AtualizarCategoriaCommandValidation : AbstractValidator<AtualizarCategoriaCommand>
    {
        //public static string MSG_ERRO_NOME => "Por favor, certifique-se de ter informado o Nome da categoria";
        //public static string MSG_ERRO_NOME_MAX_CARACTERES_NOME => $"Por favor, informa um nome com no máximo {Categoria.MAX_CARACTERES_NOME} caracteres";
        //public static string MSG_ERRO_CODIGO => "Por favor, certifique-se de ter informado o Codigo da categoria";
        //public static string MSG_ERRO_CODIGO_MAX_CARACTERES_CODIGO => $"Por favor, informe um Código com no máximo {Categoria.MAX_CARACTERES_CODIGO} caracteres";

        //public AtualizarCategoriaCommandValidation()
        //{
        //    RuleFor(c => c.Nome)
        //        .MaximumLength(250).WithMessage(MSG_ERRO_NOME_MAX_CARACTERES_NOME)
        //        .NotEmpty().WithMessage(MSG_ERRO_NOME);

        //    RuleFor(c => c.Codigo)
        //        .NotEqual("0").WithMessage(MSG_ERRO_CODIGO)
        //        .MaximumLength(3).WithMessage(MSG_ERRO_CODIGO_MAX_CARACTERES_CODIGO)
        //        .NotEmpty().WithMessage(MSG_ERRO_CODIGO);
        //}
    }
}