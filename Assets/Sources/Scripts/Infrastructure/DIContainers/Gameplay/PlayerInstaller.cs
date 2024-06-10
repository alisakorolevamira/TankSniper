﻿using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerViewFactory>().AsSingle();

            Container.Bind<CharacterAttackerPresenterFactory>().AsSingle();
            Container.Bind<CharacterAttackerViewFactory>().AsSingle();

            Container.Bind<CharacterHealthPresenterFactory>().AsSingle();
            Container.Bind<CharacterHealthViewFactory>().AsSingle();

            Container.Bind<PlayerWalletPresenterFactory>().AsSingle();
            Container.Bind<PlayerWalletViewFactory>().AsSingle();

            Container.Bind<HealthBarUIPresenterFactory>().AsSingle();
            Container.Bind<HealthBarUIFactory>().AsSingle();

            Container.Bind<WalletUIPresenterFactory>().AsSingle();
            Container.Bind<WalletUIFactory>().AsSingle();
        }
    }
}