using System;

namespace LojaVirtual.Core.DomainObject
{
    public class Entidade
    {
        public Guid Id { get; private set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public virtual void SetarId(Guid id)
        {
            Id = id;
        }

        public virtual void Validar()
        {
            throw new NotImplementedException();
        }
    }
}