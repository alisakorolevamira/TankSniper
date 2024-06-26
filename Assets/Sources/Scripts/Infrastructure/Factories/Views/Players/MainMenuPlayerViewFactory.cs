using System;
using System.Linq;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.Presentations.Views.Spawners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class MainMenuPlayerViewFactory
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuRootGameObjects _mainMenuRootGameObjects;
        private readonly PlayerWalletViewFactory _playerWalletViewFactory;
        private readonly WalletUIFactory _walletUIFactory;

        private PlayerView _playerView;

        public MainMenuPlayerViewFactory(
            MainMenuRootGameObjects mainMenuRootGameObjects,
            MainMenuHud mainMenuHud,
            PlayerWalletViewFactory playerWalletViewFactory,
            WalletUIFactory walletUIFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuRootGameObjects = mainMenuRootGameObjects ? mainMenuRootGameObjects :
                throw new ArgumentNullException(nameof(mainMenuRootGameObjects));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _playerWalletViewFactory = playerWalletViewFactory ??
                                       throw new ArgumentNullException(nameof(playerWalletViewFactory));
        }

        public PlayerView Create(int level)
        {
            if (_playerView != null) 
                _playerView.Hide();
            
           // _playerView = Object.Instantiate(
           //         Resources.Load<PlayerView>($"{PrefabPath.Player}{level}"),
           //         playerSpawnPoint.Position,
           //         playerSpawnPoint.Rotation);

           _playerView = _mainMenuRootGameObjects.PlayerViews.FirstOrDefault(x => x.Level == level);

           if (_playerView == null)
           {
               PlayerView playerView = _mainMenuRootGameObjects.PlayerViews.First(x => x.Level == 1);
               playerView.Show();
               return playerView;
           }

           _playerView.Show();
            
            return _playerView;
        }
    }
}