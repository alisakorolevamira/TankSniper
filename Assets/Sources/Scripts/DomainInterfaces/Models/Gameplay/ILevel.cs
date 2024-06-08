using System;

namespace Sources.Scripts.DomainInterfaces.Models.Gameplay
{
    public interface ILevel
    {
        event Action Completed;
        
        public bool IsCompleted { get; }
    }
}