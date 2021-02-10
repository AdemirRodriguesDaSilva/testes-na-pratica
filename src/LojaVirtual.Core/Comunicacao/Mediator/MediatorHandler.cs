using FluentValidation.Results;
using LojaVirtual.Core.Messages;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Comunicacao.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task PublicarEvento<T>(T evento) where T : Evento
        //{
        //    await _mediator.Publish(evento);
        //}

        public async Task<bool> EnviarCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                await PublicarNotificacao(new DominioNotificacao("chave", error.ErrorMessage));
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DominioNotificacao
        {
            await _mediator.Publish(notificacao);
        }
    }
}