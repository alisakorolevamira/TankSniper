using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.Skins;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.Presentations.Views.Weapons;
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
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private SkinChangerView _skinChangerView;

        public IReadOnlyList<CameraPositionView> CameraPositions => _cameraPositions;
        public IReadOnlyList<Transform> EnemyMovementPoints => _enemyMovementPoints;
        public PlayerView PlayerView => _playerView;
        public WeaponView WeaponView => _weaponView;
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
        public SkinChangerView SkinChangerView => _skinChangerView;
    }
}