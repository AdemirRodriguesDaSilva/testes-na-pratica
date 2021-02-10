using System;

namespace LojaVirtual.Core.Tests
{
    public abstract class Fixture : IDisposable
    {
        protected string IDIOMA_PORTUGUES_BRASIL => "pt_BR";

        public void Dispose()
        {
        }
    }
}