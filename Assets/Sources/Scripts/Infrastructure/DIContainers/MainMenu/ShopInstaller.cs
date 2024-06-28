using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Infrastructure.Factories.Views.Shop;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class ShopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ShopPresenterFactory>().AsSingle();
            Container.Bind<ShopViewFactory>().AsSingle();
        }
    }
}