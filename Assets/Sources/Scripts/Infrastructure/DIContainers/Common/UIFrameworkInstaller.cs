using Sources.Scripts.UIFramework.ControllerInterfaces.Signals;
using Sources.Scripts.UIFramework.Controllers.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Controllers.Views;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Forms;
using Sources.Scripts.UIFramework.Services.AudioSources;
using Sources.Scripts.UIFramework.Services.Focus;
using Sources.Scripts.UIFramework.Services.Forms;
using Sources.Scripts.UIFramework.Services.Views;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using Sources.Scripts.UIFramework.ServicesInterfaces.Views;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class UIFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();

            Container.Bind<UICollectorFactory>().AsSingle();

            Container.Bind<UIViewFactory>().AsSingle();
            Container.Bind<UIViewPresenterFactory>().AsSingle();
            
            Container.Bind<IUIViewService>().To<UIViewService>().AsSingle();
            
            Container.Bind<ISignalController>().To<ButtonCommandSignalController>().AsSingle();

            Container.Bind<IFocusService>().To<FocusService>().AsSingle();
        }
    }
}