using System;

namespace Sources.Scripts.DomainInterfaces.Models.Common
{
    public interface ICharacterHealth
    {
        event Action Die;
        bool IsDied { get; }
    }
}