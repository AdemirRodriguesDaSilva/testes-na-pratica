using System;

namespace LojaVirtual.Core.Messages
{
    public abstract class Message
    {
        public string TipoMensagem { get; protected set; }
        public Guid RaizDeAgregacaoId { get; protected set; }

        protected Message()
        {
            TipoMensagem = GetType().Name;
        }
    }
}