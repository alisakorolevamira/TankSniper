using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class PlayerViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly GameplayRootGameObject _gameplayRootGameObject;
        private readonly PlayerAttackerViewFactory _playerAttackerViewFactory;
        private readonly CharacterHealthViewFactory _characterHealthViewFactory;
        private readonly PlayerWalletViewFactory _playerWalletViewFactory;
        private readonly WalletUIFactory _walletUIFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly WeaponViewFactory _weaponViewFactory;
        private readonly AttackerUIViewFactory _attackerUIViewFactory;

        public PlayerViewFactory(
            GameplayRootGameObject gameplayRootGameObject,
            GameplayHud gameplayHud,
            PlayerAttackerViewFactory playerAttackerViewFactory,
            CharacterHealthViewFactory characterHealthViewFactory,
            PlayerWalletViewFactory playerWalletViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            WalletUIFactory walletUIFactory,
            WeaponViewFactory weaponViewFactory,
            AttackerUIViewFactory attackerUIViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayRootGameObject = gameplayRootGameObject ? gameplayRootGameObject :
                throw new ArgumentNullException(nameof(gameplayRootGameObject));
            _playerAttackerViewFactory = playerAttackerViewFactory ??
                                         throw new ArgumentNullException(nameof(playerAttackerViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _characterHealthViewFactory = characterHealthViewFactory ??
                                              throw new ArgumentNullException(nameof(characterHealthViewFactory));
            _playerWalletViewFactory = playerWalletViewFactory ??
                                       throw new ArgumentNullException(nameof(playerWalletViewFactory));
            _weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
            _attackerUIViewFactory = attackerUIViewFactory ??
                                     throw new ArgumentNullException(nameof(attackerUIViewFactory));
        }

        public PlayerView Create(GameplayPlayer player, SkinChanger skinChanger, int level)
        {
           PlayerView playerView = _gameplayRootGameObject.PlayerView;
           
           skinChanger.ChangeSkin(level);
           
            _playerAttackerViewFactory.Create(player.PlayerAttacker, playerView.PlayerAttackerView);

            _characterHealthViewFactory.Create(player.CharacterHealth, playerView.PlayerHealthView);

            foreach (WalletUI wallet in _gameplayHud.WalletsUI) 
                _walletUIFactory.Create(player.PlayerWallet, wallet);

            foreach (HealthBarUI healthBar in _gameplayHud.PlayerHealthBarUIs) 
                _healthBarUIFactory.Create(player.CharacterHealth, healthBar);

            _attackerUIViewFactory.Create(_gameplayHud.AttackerUIView);
            _weaponViewFactory.Create(player.Weapon, _gameplayRootGameObject.WeaponView);
            
            return playerView;
        }
    }
}