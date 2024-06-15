using Sources.Scripts.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class MainMenuRootGameObjects : View
    {
        [Header("Player")]
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;

        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
    }
}