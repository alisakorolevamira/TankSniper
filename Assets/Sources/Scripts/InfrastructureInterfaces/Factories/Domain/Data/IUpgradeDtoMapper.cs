using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Upgrades;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IUpgradeDtoMapper
    {
        UpgradeDto MapModelToDto(Upgrader upgrader);
        Upgrader MapDtoToModel(UpgradeDto upgradeDto);
    }
}