﻿using Sources.Scripts.Infrastructure.Services.Yandex;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class SDKInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerAccountAuthorizeService>().To<PlayerAccountAuthorizeService>().AsSingle();
            Container.Bind<ISDKInitializeService>().To<SDKInitializeService>().AsSingle();
            Container.Bind<IInterstitialAdService>().To<InterstitialAdService>().AsSingle();
            Container.Bind<IRewardedAdService>().To<RewardedAdService>().AsSingle();
        }
    }
}