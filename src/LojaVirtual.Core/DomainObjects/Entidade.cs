using FluentValidation.Results;
using System;

namespace LojaVirtual.Core.DomainObject
{
    public class Entidade
    {
        public Guid Id { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}