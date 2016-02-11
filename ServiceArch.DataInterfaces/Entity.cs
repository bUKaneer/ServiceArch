using ServiceArch.DataInterfaces.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceArch.DataInterfaces
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            
        }

        protected Entity(Guid id) 
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; set; }
    }
}
