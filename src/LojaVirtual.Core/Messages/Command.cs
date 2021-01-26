using FluentValidation.Results;
using LojaVirtual.Core.DomainObjects;
using MediatR;
using System;
using System.Threading;

namespace LojaVirtual.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        private readonly IMediator _mediator;

        public DateTime Data { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            Data = DateTime.Now;
        }

        protected Command(IMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract bool EhValido();

        public bool ValidarCommand(Command command)
        {
            if (command.EhValido())
                return true;

            foreach (var error in command.ValidationResult.Errors)
                _mediator.Publish(new NotificacaoDoDominio(command.TipoMensagem, error.ErrorMessage), CancellationToken.None);

            return false;
        }
    }
}