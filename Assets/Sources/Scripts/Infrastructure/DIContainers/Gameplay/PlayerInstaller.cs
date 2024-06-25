using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerViewFactory>().AsSingle();

            Container.Bind<IPlayerAttackService>().To<PlayerAttackService>().AsSingle();

            Container.Bind<PlayerAttackerPresenterFactory>().AsSingle();
            Container.Bind<PlayerAttackerViewFactory>().AsSingle();

            Container.Bind<CharacterHealthPresenterFactory>().AsSingle();
            Container.Bind<CharacterHealthViewFactory>().AsSingle();

            Container.Bind<HealthBarUIPresenterFactory>().AsSingle();
            Container.Bind<HealthBarUIFactory>().AsSingle();

            Container.Bind<AttackerUIPresenterFactory>().AsSingle();
            Container.Bind<AttackerUIViewFactory>().AsSingle();

            Container.Bind<RewardPresenterFactory>().AsSingle();
            Container.Bind<RewardViewFactory>().AsSingle();
        }
    }
}