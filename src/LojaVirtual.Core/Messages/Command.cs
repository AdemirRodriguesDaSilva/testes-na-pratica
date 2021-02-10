using FluentValidation;
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

        public bool ValidarCommand(Command command, IMediator mediator)
        {
            if (command.EhValido())
                return true;

            PublicarErrosVaidationResult(command, mediator);

            return false;
        }

        public void PublicarErrosVaidationResult(Command command, IMediator mediator)
        {
            foreach (var error in command.ValidationResult.Errors)
                mediator.Publish(new DominioNotificacao(command.TipoMensagem, error.ErrorMessage), CancellationToken.None);
        }

        public abstract bool EhValido();

        public bool Validar<Command>(Command command, AbstractValidator<Command> validator)
        {
            ValidationResult = validator.Validate(command);
            return ValidationResult.IsValid;
        }
    }
}