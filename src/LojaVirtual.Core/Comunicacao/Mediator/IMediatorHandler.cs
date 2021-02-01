using LojaVirtual.Core.DomainObjects;
using LojaVirtual.Core.Messages;
using LojaVirtual.Core.Messages.Notificacao;
using System.Threading.Tasks;

namespace LojaVirtual.Core.Comunicacao
{
    public interface IMediatorHandler
    {
        //Task PublicarEvento<T>(T evento) where T : Evento;
        Task<bool> EnviarCommand<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DominioNotificacao;
    }
}