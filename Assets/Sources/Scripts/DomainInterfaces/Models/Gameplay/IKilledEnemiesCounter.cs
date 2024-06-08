using System;

namespace Sources.Scripts.DomainInterfaces.Models.Gameplay
{
    public interface IKilledEnemiesCounter
    {
        event Action KilledEnemiesCountChanged;
        
        public int KilledEnemies { get; }

        void IncreaseKilledEnemiesCount();
    }
}