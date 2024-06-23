using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.Infrastructure.Services.UpgradeServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuPlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuPlayerViewFactory>().AsSingle();

            Container.Bind<IPlayerSpawnerService>().To<PlayerSpawnerService>().AsSingle();

            Container.Bind<IUpgradeService>().To<UpgradeService>().AsSingle();

            //Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            //Container.Bind<PlayerWalletViewFactory>().AsSingle();

            //Container.Bind<WalletUIPresenterFactory>().AsSingle();
            //Container.Bind<WalletUIFactory>().AsSingle();
        }
    }
}