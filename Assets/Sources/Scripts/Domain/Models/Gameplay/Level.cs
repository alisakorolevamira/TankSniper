using System;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class Level : ILevel
    {
        public Level(string id, bool isCompleted)
        {
            Id = id;
            IsCompleted = isCompleted;
        }

        public event Action Completed;
        
        public bool IsCompleted { get; private set; }
        public string Id { get; }

        public void Complete()
        {
            IsCompleted = true;
            Completed?.Invoke();
        }
    }
}