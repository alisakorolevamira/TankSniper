using System;

namespace Sources.Scripts.DomainInterfaces.Models.Entities
{
    public interface IEntity
    {
        string Id { get; }
        Type Type { get; }
    }
}