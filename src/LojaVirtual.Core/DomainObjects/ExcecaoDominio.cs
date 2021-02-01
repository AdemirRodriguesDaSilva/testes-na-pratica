using System;

namespace LojaVirtual.Core.DomainObjects
{
    public class ExcessaoDoDominio : Exception
    {
        public ExcessaoDoDominio()
        {
        }

        public ExcessaoDoDominio(string mensagem) : base(mensagem)
        {
        }

        public ExcessaoDoDominio(string mensagem, Exception excecao) : base(mensagem, excecao)
        {
        }
    }
}