using MediatR;
using System;

namespace LojaVirtual.Core.Messages.Notificacao
{
    public class DominioNotificacao : Mensage, INotification
    {
        public DateTime DataHora { get; private set; }
        public Guid DominioNotificacaoId { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public DominioNotificacao(string chave, string valor)
        {
            DataHora = DateTime.Now;
            DominioNotificacaoId = Guid.NewGuid();
            Chave = chave;
            Versao = 1;
            Valor = valor;
        }
    }
}