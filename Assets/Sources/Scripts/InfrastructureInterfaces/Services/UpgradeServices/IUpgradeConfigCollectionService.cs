using Sources.Scripts.Domain.Models.Upgrades.Configs;

namespace Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices
{
    public interface IUpgradeConfigCollectionService
    {
        UpgradeConfig GetConfig(string id);
    }
}