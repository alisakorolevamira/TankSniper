using Sources.Scripts.Presentations.Views.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class PlayerView : View
    {
        [SerializeField] private CharacterHealthView _playerHealthView;
        [SerializeField] private PlayerWalletView _playerWalletView;

        public CharacterHealthView PlayerHealthView => _playerHealthView;
        public PlayerWalletView PlayerWalletView => _playerWalletView;
    }
}