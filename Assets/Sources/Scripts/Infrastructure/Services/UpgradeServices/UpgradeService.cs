using System;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;

namespace Sources.Scripts.Infrastructure.Services.UpgradeServices
{
    public class UpgradeService : IUpgradeService
    {
        private Upgrader _upgrader;
        
        public event Action<int> LevelChanged;

        public void Register(Upgrader upgrader) => 
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));

        public void CheckLevel(int level)
        {
            if (level > _upgrader.CurrentLevel)
            {
                _upgrader.Upgrade();
                LevelChanged?.Invoke(_upgrader.CurrentLevel);
            }
        }
    }
}