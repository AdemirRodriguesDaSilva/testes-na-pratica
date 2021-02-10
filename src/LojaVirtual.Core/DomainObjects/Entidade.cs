using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Core.DomainObject
{
    public class Entidade
    {
        public Guid Id { get; private set; }
        
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public virtual void Validar()
        {
            throw new NotImplementedException();
        }
    }
}