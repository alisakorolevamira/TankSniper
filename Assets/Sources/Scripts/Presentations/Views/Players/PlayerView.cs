using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class PlayerView : View, IPlayerView
    {
        [SerializeField] private CharacterHealthView _playerHealthView;
        [SerializeField] private PlayerAttackerView _playerAttackerView;

        public CharacterHealthView PlayerHealthView => _playerHealthView;
        public PlayerAttackerView PlayerAttackerView => _playerAttackerView;
    }
}