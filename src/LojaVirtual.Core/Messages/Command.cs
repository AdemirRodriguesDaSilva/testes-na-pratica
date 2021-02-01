using FluentValidation.Results;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using System;
using System.Threading;

namespace LojaVirtual.Core.Messages
{
    public abstract class Command : Mensage, IRequest<bool>
    {
        public DateTime Data { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            Data = DateTime.Now;
        }

        public abstract bool EhValido();

        public bool ValidarCommand(Command command, IMediator mediator)
        {
            if (command.EhValido())
                return true;

            foreach (var error in command.ValidationResult.Errors)
                mediator.Publish(new DominioNotificacao(command.TipoMensagem, error.ErrorMessage), CancellationToken.None);

            return false;
        }
    }
}