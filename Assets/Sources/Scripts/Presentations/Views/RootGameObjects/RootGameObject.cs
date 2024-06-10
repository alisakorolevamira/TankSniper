using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [SerializeField] private CameraPositionView _cameraPosition;
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private EnemySpawnerView _enemySpawnerView;

        public CameraPositionView CameraPosition => _cameraPosition;
        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
    }
}