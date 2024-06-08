using System;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class KilledEnemiesCounter : IKilledEnemiesCounter
    {
        public event Action KilledEnemiesCountChanged;
        public int KilledEnemies { get; private set; }
        
        public void IncreaseKilledEnemiesCount()
        {
            KilledEnemies++;
            KilledEnemiesCountChanged?.Invoke();
        }
    }
}