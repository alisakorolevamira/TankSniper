using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Infrastructure.Factories.Domain.Data;
using Sources.Scripts.Infrastructure.Services.LoadServices.Collectors;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices.Collectors;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class DtoFactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMapperCollector>().To<MapperCollector>().AsSingle();

            Container.Bind<IUpgradeDtoMapper>().To<UpgradeDtoMapper>().AsSingle();
            Container.Bind<IPlayerWalletDtoMapper>().To<PlayerWalletDtoMapper>().AsSingle();
            Container.Bind<ILevelDtoMapper>().To<LevelDtoMapper>().AsSingle();
            Container.Bind<IVolumeDtoMapper>().To<VolumeDtoMapper>().AsSingle();
            Container.Bind<ITutorialDtoMapper>().To<TutorialDtoMapper>().AsSingle();
            Container.Bind<IGameDataDtoMapper>().To<GameDataDtoMapper>().AsSingle();
            Container.Bind<ISavedLevelDtoMapper>().To<SavedLevelDtoMapper>().AsSingle();
            Container.Bind<IInventorySlotDtoMapper>().To<InventorySlotDtoMapper>().AsSingle();
            Container.Bind<IShopPatternButtonDtoMapper>().To<ShopPatternButtonDtoMapper>().AsSingle();
        }
    }
}