using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Shop;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Shop.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuUIFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IButtonCommandHandler>().To<MainMenuButtonCommandHandler>().AsSingle();

            Container.Bind<CompleteTutorialCommand>().AsSingle();
            Container.Bind<LoadGameCommand>().AsSingle();
            Container.Bind<AddTankCommand>().AsSingle();
            Container.Bind<ChangeVolumeCommand>().AsSingle();
            
            Container.Bind<IShopCommandHandler>().To<ShopCommandHandler>().AsSingle();

            Container.Bind<SetSkinCommand>().AsSingle();
            Container.Bind<SetMaterialCommand>().AsSingle();
        }
    }
}