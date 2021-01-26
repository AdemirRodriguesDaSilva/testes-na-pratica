using System;

namespace LojaVirtual.Core.DomainObject
{
    public class ExcecaoDoDominio : Exception
    {
        public ExcecaoDoDominio()
        {
        }

        public ExcecaoDoDominio(string mensagem)
        {
        }

        public ExcecaoDoDominio(string mensagem, Exception exception) : base(mensagem, exception)
        {
        }
    }
}