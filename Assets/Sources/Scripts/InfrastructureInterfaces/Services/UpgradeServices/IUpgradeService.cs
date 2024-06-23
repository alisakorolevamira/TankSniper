using System;
using Sources.Scripts.Domain.Models.Upgrades;

namespace Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices
{
    public interface IUpgradeService
    {
        event Action<int> LevelChanged;

        void Register(Upgrader upgrader);

        void CheckLevel(int level);
    }
}