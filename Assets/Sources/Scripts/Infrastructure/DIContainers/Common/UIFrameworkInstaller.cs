using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Forms;
using Sources.Scripts.UIFramework.ControllerInterfaces.Shop;
using Sources.Scripts.UIFramework.Controllers.Buttons;
using Sources.Scripts.UIFramework.Controllers.Forms;
using Sources.Scripts.UIFramework.Controllers.Shop;
using Sources.Scripts.UIFramework.Services.AudioSources;
using Sources.Scripts.UIFramework.Services.Focus;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class UIFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<IButtonSignalController>().To<ButtonCommandSignalController>().AsSingle();
            Container.Bind<IFormSignalController>().To<FormCommandSignalController>().AsSingle();
            Container.Bind<IShopSignalController>().To<ShopCommandSignalController>().AsSingle();
            Container.Bind<IFocusService>().To<FocusService>().AsSingle();
        }
    }
}