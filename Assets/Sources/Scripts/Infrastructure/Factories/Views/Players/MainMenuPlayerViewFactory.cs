using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
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

        public MainMenuPlayerViewFactory(
            MainMenuRootGameObjects mainMenuRootGameObjects,
            MainMenuHud mainMenuHud,
            PlayerWalletViewFactory playerWalletViewFactory,
            WalletUIFactory walletUIFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuRootGameObjects = mainMenuRootGameObjects ?? throw new ArgumentNullException(nameof(mainMenuRootGameObjects));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _playerWalletViewFactory = playerWalletViewFactory ??
                                       throw new ArgumentNullException(nameof(playerWalletViewFactory));
        }

        public PlayerView Create(Player player)
        {
            PlayerView playerView =
                Object.Instantiate(
                    Resources.Load<PlayerView>(PrefabPath.Player),
                    _mainMenuRootGameObjects.PlayerSpawnPoint.Position,
                    _mainMenuRootGameObjects.PlayerSpawnPoint.Rotation);
            
            foreach (WalletUI wallet in _mainMenuHud.WalletsUI) 
                _walletUIFactory.Create(player.PlayerWallet, wallet);
            
            return playerView;
        }
    }
}