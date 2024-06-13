﻿using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [SerializeField] private List<CameraPositionView> _cameraPositions;
        [SerializeField] private List<Transform> _enemyMovementPoints;
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private EnemySpawnerView _enemySpawnerView;
        [SerializeField] private PlayerAttackerView _playerAttackerView;

        public IReadOnlyList<CameraPositionView> CameraPositions => _cameraPositions;
        public IReadOnlyList<Transform> EnemyMovementPoints => _enemyMovementPoints;
        public PlayerAttackerView PlayerAttackerView => _playerAttackerView;
        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public EnemySpawnerView EnemySpawnerView => _enemySpawnerView;
    }
}