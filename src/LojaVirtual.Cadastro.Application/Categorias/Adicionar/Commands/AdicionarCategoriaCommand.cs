using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Validations;
using LojaVirtual.Core.Messages;

namespace LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands
{
    public class AdicionarCategoriaCommand : Command
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public bool Ativo { get; private set; }

        protected AdicionarCategoriaCommand()
        {
            Ativar();
        }

        public AdicionarCategoriaCommand(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Ativar();
        }

        public void Ativar() => Ativo = true;

        public override bool EhValido()
        {
            ValidationResult = new AdicionarCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid && Ativo;
        }
    }
}