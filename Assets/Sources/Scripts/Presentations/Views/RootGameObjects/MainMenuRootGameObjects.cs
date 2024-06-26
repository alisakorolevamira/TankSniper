using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class MainMenuRootGameObjects : View
    {
        [Header("Player")]
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private List<PlayerView> _playerViews;

        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public IReadOnlyList<PlayerView> PlayerViews => _playerViews;
    }
}