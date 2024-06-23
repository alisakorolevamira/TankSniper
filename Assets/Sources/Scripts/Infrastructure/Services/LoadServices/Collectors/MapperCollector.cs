using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices.Collectors;

namespace Sources.Scripts.Infrastructure.Services.LoadServices.Collectors
{
    public class MapperCollector : IMapperCollector
    {
        private readonly Dictionary<Type, Func<IEntity, IDto>> _toDtoMappers;
        private readonly Dictionary<Type, Func<IDto, IEntity>> _toModelMappers;

        public MapperCollector(
            IUpgradeDtoMapper upgradeDtoMapper,
            IPlayerWalletDtoMapper playerWalletDtoMapper,
            IVolumeDtoMapper volumeDtoMapper,
            ILevelDtoMapper levelDtoMapper,
            IGameDataDtoMapper gameDataDtoMapper,
            ITutorialDtoMapper tutorialDtoMapper,
            ISavedLevelDtoMapper savedLevelDtoMapper,
            IInventorySlotDtoMapper inventorySlotDtoMapper)
        {
            _toDtoMappers = new Dictionary<Type, Func<IEntity, IDto>>();
            _toDtoMappers[typeof(Upgrader)] =
                model => upgradeDtoMapper.MapModelToDto(model as Upgrader);
            _toDtoMappers[typeof(PlayerWallet)] =
                model => playerWalletDtoMapper.MapModelToDto(model as PlayerWallet);
            _toDtoMappers[typeof(Volume)] =
                model => volumeDtoMapper.MapModelToDto(model as Volume);
            _toDtoMappers[typeof(Level)] =
                model => levelDtoMapper.MapModelToDto(model as Level);
            _toDtoMappers[typeof(GameData)] =
                model => gameDataDtoMapper.MapModelToDto(model as GameData);
            _toDtoMappers[typeof(Tutorial)] =
                model => tutorialDtoMapper.MapModelToDto(model as Tutorial);
            _toDtoMappers[typeof(SavedLevel)] =
                model => savedLevelDtoMapper.MapModelToDto(model as SavedLevel);
            _toDtoMappers[typeof(InventorySlot)] =
                model => inventorySlotDtoMapper.MapModelToDto(model as InventorySlot);

            _toModelMappers = new Dictionary<Type, Func<IDto, IEntity>>();
            _toModelMappers[typeof(UpgradeDto)] =
                dto => upgradeDtoMapper.MapDtoToModel(dto as UpgradeDto);
            _toModelMappers[typeof(PlayerWalletDto)] =
                dto => playerWalletDtoMapper.MapDtoToModel(dto as PlayerWalletDto);
            _toModelMappers[typeof(VolumeDto)] =
                dto => volumeDtoMapper.MapDtoToModel(dto as VolumeDto);
            _toModelMappers[typeof(LevelDto)] =
                dto => levelDtoMapper.MapDtoToModel(dto as LevelDto);
            _toModelMappers[typeof(GameDataDto)] =
                dto => gameDataDtoMapper.MapDtoToModel(dto as GameDataDto);
            _toModelMappers[typeof(TutorialDto)] =
                dto => tutorialDtoMapper.MapDtoToModel(dto as TutorialDto);
            _toModelMappers[typeof(SavedLevelDto)] =
                dto => savedLevelDtoMapper.MapDtoToModel(dto as SavedLevelDto);
            _toModelMappers[typeof(InventorySlotDto)] =
                dto => inventorySlotDtoMapper.MapDtoToModel(dto as InventorySlotDto);
        }

        public Func<IEntity, IDto> GetToDtoMapper(Type type)
        {
            if(_toDtoMappers.ContainsKey(type) == false)
                throw new NullReferenceException($"DtaModel Id {type} not registered in MapperCollector.");
            
            return _toDtoMappers[type];
        }

        public Func<IDto, IEntity> GetToModelMapper(Type type)
        {
            if(_toModelMappers.ContainsKey(type) == false)
                throw new NullReferenceException($"DtaModel Id {type} not registered in MapperCollector.");
            
            return _toModelMappers[type];
        }
    }
}