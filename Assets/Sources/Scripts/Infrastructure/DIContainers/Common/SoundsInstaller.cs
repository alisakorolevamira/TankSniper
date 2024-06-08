using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class SoundsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<VolumePresenterFactory>().AsSingle();
            Container.Bind<VolumeViewFactory>().AsSingle();
        }
    }
}