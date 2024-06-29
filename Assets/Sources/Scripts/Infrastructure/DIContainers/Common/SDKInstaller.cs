using Sources.Scripts.Infrastructure.Services.Yandex;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.UIFramework.Services.Focus;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class SDKInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerAccountAuthorizeService>().To<PlayerAccountAuthorizeService>().AsSingle();
            Container.Bind<ISDKInitializeService>().To<SDKInitializeService>().AsSingle();
            Container.Bind<IStickyAdService>().To<StickyAdService>().AsSingle();
            Container.Bind<IRewardedAdService>().To<RewardedAdService>().AsSingle();
        }
    }
}