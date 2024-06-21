using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class PlayerWalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            Container.Bind<PlayerWalletViewFactory>().AsSingle();
            
            Container.Bind<WalletUIPresenterFactory>().AsSingle();
            Container.Bind<WalletUIFactory>().AsSingle();
        }
    }
}