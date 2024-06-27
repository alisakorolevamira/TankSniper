using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class CommonPlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            Container.Bind<PlayerWalletViewFactory>().AsSingle();
            
            Container.Bind<WalletUIPresenterFactory>().AsSingle();
            Container.Bind<WalletUIFactory>().AsSingle();

            Container.Bind<SkinChangerPresenterFactory>().AsSingle();
            Container.Bind<SkinChangerViewFactory>().AsSingle();
        }
    }
}