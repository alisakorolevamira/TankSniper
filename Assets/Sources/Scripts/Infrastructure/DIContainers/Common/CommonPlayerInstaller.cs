using Sources.Scripts.Domain.Models.Players.Configs;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class CommonPlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerViewMaterialsConfig>()
                .FromResource("Configs/PlayerViewMaterialsConfig")
                .AsSingle();
            
            Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            Container.Bind<PlayerWalletViewFactory>().AsSingle();
            
            Container.Bind<WalletUIPresenterFactory>().AsSingle();
            Container.Bind<WalletUIFactory>().AsSingle();

            Container.Bind<SkinChangerPresenterFactory>().AsSingle();
            Container.Bind<SkinChangerViewFactory>().AsSingle();
            
            Container.Bind<ISkinChangerService>().To<SkinChangerService>().AsSingle();
        }
    }
}