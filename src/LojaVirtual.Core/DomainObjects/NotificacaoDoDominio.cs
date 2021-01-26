using LojaVirtual.Core.Messages;
using MediatR;
using System;

namespace LojaVirtual.Core.DomainObjects
{
    public class NotificacaoDoDominio : Message, INotification
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }

        public NotificacaoDoDominio(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }
    }
}