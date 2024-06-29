using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class UpgradeDtoMapper : IUpgradeDtoMapper
    {
        public UpgradeDto MapModelToDto(Upgrader upgrader)
        {
            return new UpgradeDto()
            {
                CurrentLevel = upgrader.CurrentLevel,
                Id = upgrader.Id
            };
        }

        public Upgrader MapDtoToModel(UpgradeDto upgradeDto) => 
            new(upgradeDto.CurrentLevel, upgradeDto.Id);
    }
}