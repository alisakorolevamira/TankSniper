using Sources.Scripts.Presentations.Views.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class PlayerView : View
    {
        [SerializeField] private CharacterHealthView _playerHealthView;
        [SerializeField] private PlayerAttackerView _playerAttackerView;

        public CharacterHealthView PlayerHealthView => _playerHealthView;
        public PlayerAttackerView PlayerAttackerView => _playerAttackerView;
    }
}