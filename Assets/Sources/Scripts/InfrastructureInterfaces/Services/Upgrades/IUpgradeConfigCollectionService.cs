using Sources.Scripts.Domain.Models.Upgrades.Configs;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeConfigCollectionService
    {
        UpgradeConfig GetConfig(string id);
    }
}