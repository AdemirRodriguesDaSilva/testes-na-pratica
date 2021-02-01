using System;

namespace LojaVirtual.Core.Messages
{
    public abstract class Mensage
    {
        public string TipoMensagem { get; protected set; }
        public Guid RaizDeAgregacaoId { get; protected set; }

        protected Mensage()
        {
            TipoMensagem = GetType().Name;
        }
    }
}