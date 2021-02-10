using LojaVirtual.Core.Messages;
using System;

namespace LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands
{
    public partial class AtualizarCategoriaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public bool Ativo { get; private set; }

        protected AtualizarCategoriaCommand()
        {
        }

        public AtualizarCategoriaCommand(Guid id, string nome, string codigo, bool ativo)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            Ativo = ativo;
        }

        public override bool EhValido()
        {
            return Validar(this, new AtualizarCategoriaCommandValidation());
        }
    }
}