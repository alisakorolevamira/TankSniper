using Sources.Scripts.Domain.Models.Players.Configs;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Infrastructure.Factories.Views.Shop;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class ShopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerViewMaterialsConfig>()
                .FromResource("Configs/PlayerViewMaterialsConfig")
                .AsSingle();
            
            Container.Bind<ShopPresenterFactory>().AsSingle();
            Container.Bind<ShopViewFactory>().AsSingle();

            Container.Bind<ShopPatternButtonPresenterFactory>().AsSingle();
            Container.Bind<ShopPatternButtonViewFactory>().AsSingle();

            Container.Bind<ShopDecalButtonPresenterFactory>().AsSingle();
            Container.Bind<ShopDecalButtonViewFactory>().AsSingle();
        }
    }
}