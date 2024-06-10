using Sources.Scripts.Presentations.Views.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class PlayerView : View
    {
        [FormerlySerializedAs("_playerHealthView")] [SerializeField] private CharacterHealthView characterHealthView;
        [SerializeField] private PlayerWalletView _playerWalletView;

        public CharacterHealthView CharacterHealthView => characterHealthView;
        public PlayerWalletView PlayerWalletView => _playerWalletView;
        public Transform Transform => transform;
    }
}