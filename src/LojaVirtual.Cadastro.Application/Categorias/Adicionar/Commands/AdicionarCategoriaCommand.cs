using LojaVirtual.Core.Messages;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommand : Command
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        protected AdicionarCategoriaCommand()
        {
        }

        public AdicionarCategoriaCommand(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}