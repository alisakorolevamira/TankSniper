using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class PlayerViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly RootGameObject _rootGameObject;
        //private readonly CharacterAttackerViewFactory _characterAttackerViewFactory;
        private readonly CharacterHealthViewFactory characterHealthViewFactory;
        private readonly PlayerWalletViewFactory _playerWalletViewFactory;
        private readonly WalletUIFactory _walletUIFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;

        public PlayerViewFactory(
            RootGameObject rootGameObject,
            GameplayHud gameplayHud,
            //CharacterAttackerViewFactory characterAttackerViewFactory,
            CharacterHealthViewFactory characterHealthViewFactory,
            PlayerWalletViewFactory playerWalletViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            WalletUIFactory walletUIFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _rootGameObject = rootGameObject ?? throw new ArgumentNullException(nameof(rootGameObject));
            //_characterAttackerViewFactory = characterAttackerViewFactory ??
             //                               throw new ArgumentNullException(nameof(characterAttackerViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            this.characterHealthViewFactory = characterHealthViewFactory ??
                                              throw new ArgumentNullException(nameof(characterHealthViewFactory));
            _playerWalletViewFactory = playerWalletViewFactory ??
                                       throw new ArgumentNullException(nameof(playerWalletViewFactory));

        }

        public PlayerView Create(Player player)
        {
            PlayerView playerView =
                Object.Instantiate(
                    Resources.Load<PlayerView>(PrefabPath.Player),
                    _rootGameObject.PlayerSpawnPoint.Position,
                    Quaternion.identity);
            
            //_characterAttackerViewFactory.Create(character.CharacterAttacker, characterView.CharacterAttackerView);

            characterHealthViewFactory.Create(player.CharacterHealth, playerView.CharacterHealthView);
            _playerWalletViewFactory.Create(player.PlayerWallet, playerView.PlayerWalletView);
            _healthBarUIFactory.Create(player.CharacterHealth, _gameplayHud.PlayerHealthBarUI);
            _walletUIFactory.Create(player.PlayerWallet, _gameplayHud.WalletUI);
            
            return playerView;
        }
    }
}