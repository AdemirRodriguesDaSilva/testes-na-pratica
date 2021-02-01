using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Messages.Notificacao
{
    public class DominioNotificacaoHandler : INotificationHandler<DominioNotificacao>
    {
        private List<DominioNotificacao> _notificacoes;

        public DominioNotificacaoHandler()
        {
            _notificacoes = new List<DominioNotificacao>();
        }

        public Task Handle(DominioNotificacao notificacao, CancellationToken cancellationToken)
        {
            _notificacoes.Add(notificacao);
            return Task.CompletedTask;
        }

        public virtual bool TemNotificacao()
        {
            return ObterNotificacoes().Any();
        }

        public virtual List<DominioNotificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public void Dispose()
        {
            _notificacoes = new List<DominioNotificacao>();
        }
    }
}