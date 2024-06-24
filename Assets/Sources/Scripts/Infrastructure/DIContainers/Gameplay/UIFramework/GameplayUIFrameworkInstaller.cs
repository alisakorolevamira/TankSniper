using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Forms;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Forms.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay.UIFramework
{
    public class GameplayUIFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IButtonCommandHandler>().To<GameplayButtonCommandHandler>().AsSingle();
            
            Container.Bind<LoadMainMenuSceneCommand>().AsSingle(); 
            Container.Bind<LoadGameCommand>().AsSingle();
            Container.Bind<ChangeVolumeCommand>().AsSingle();
            
            Container.Bind<IUIViewCommandHandler>().To<GameplayUIViewCommandHandler>().AsSingle();
            
            Container.Bind<UnPauseCommand>().AsSingle();
            Container.Bind<PauseCommand>().AsSingle();
            Container.Bind<SetCameraToShootPositionCommand>().AsSingle();
            Container.Bind<SetCameraToMainPositionCommand>().AsSingle();
            Container.Bind<ReloadWeaponCommand>().AsSingle();
        }
    }
}