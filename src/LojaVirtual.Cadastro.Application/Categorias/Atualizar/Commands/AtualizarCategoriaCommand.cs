using LojaVirtual.Core.Messages;

namespace LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands
{
    public partial class AtualizarCategoriaCommand : Command
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }

        protected AtualizarCategoriaCommand()
        {
        }

        public AtualizarCategoriaCommand(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}