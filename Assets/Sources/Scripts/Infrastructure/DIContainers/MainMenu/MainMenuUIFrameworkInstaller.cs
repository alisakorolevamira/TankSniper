using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Forms;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Forms.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuUIFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IButtonCommandHandler>().To<MainMenuButtonCommandHandler>().AsSingle();

            Container.Bind<ShowFormCommand>().AsSingle();
            Container.Bind<HideFormCommand>().AsSingle();
            Container.Bind<CompleteTutorialCommand>().AsSingle();
            Container.Bind<LoadGameCommand>().AsSingle();
            Container.Bind<AddTankCommand>().AsSingle();

            Container.Bind<IUIViewCommandHandler>().To<MainMenuUIViewCommandHandler>().AsSingle();

            Container.Bind<UnPauseCommand>().AsSingle();
            Container.Bind<PauseCommand>().AsSingle();
            Container.Bind<SaveVolumeCommand>().AsSingle();
        }
    }
}