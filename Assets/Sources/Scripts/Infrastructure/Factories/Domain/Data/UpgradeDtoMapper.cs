using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Upgrades.Configs;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class UpgradeDtoMapper : IUpgradeDtoMapper
    {
        //private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;

       // public UpgradeDtoMapper(IUpgradeConfigCollectionService upgradeConfigCollectionService)
       // {
       //     //_upgradeConfigCollectionService = 
       //     //    upgradeConfigCollectionService ?? 
       //     //    throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
       // }

        public UpgradeDto MapModelToDto(Upgrader upgrader)
        {
            return new UpgradeDto()
            {
                CurrentLevel = upgrader.CurrentLevel,
                Id = upgrader.Id
            };
        }

        public UpgradeDto MapIdToDto(string id)
        {
            //UpgradeConfig upgradeConfig = _upgradeConfigCollectionService.GetConfig(id);

            return new UpgradeDto();
        }

        public Upgrader MapDtoToModel(UpgradeDto upgradeDto) => 
            new(upgradeDto.CurrentLevel, upgradeDto.Id);
    }
}