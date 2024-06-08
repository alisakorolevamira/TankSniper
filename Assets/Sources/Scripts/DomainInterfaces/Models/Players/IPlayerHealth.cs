using System;

namespace Sources.Scripts.DomainInterfaces.Models.Players
{
    public interface IPlayerHealth
    {
        event Action PlayerDie;
        bool IsDied { get; }
    }
}