using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class GameplayRootGameObject : View
    {
        [Header("Camera")]
        [SerializeField] private List<CameraPositionView> _cameraPositions;
        
        [Header("Enemy")]
        [SerializeField] private List<Transform> _enemyMovementPoints;
        [SerializeField] private EnemySpawnerView _enemySpawnerView;
        
        [Header("Player")]
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private WeaponView _weaponView;

        public IReadOnlyList<CameraPositionView> CameraPositions => _cameraPositions;
        public IReadOnlyList<Transform> EnemyMovementPoints => _enemyMovementPoints;
        public WeaponView WeaponView => _weaponView;
        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
    }
}