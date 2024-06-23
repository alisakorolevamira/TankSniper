using System;

namespace Sources.Scripts.DomainInterfaces.Models.Gameplay
{
    public interface ILevel
    {
        event Action Completed;
        
        bool IsCompleted { get; }
    }
}