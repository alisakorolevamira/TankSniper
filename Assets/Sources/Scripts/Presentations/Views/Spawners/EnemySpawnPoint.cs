using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnPoint : View, IEnemySpawnPoint
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private List<Transform> _points;

        public EnemyView EnemyView => _enemyView;
        public EnemyType EnemyType => _enemyType;
        public Vector3 Position => transform.position;
        public IReadOnlyList<Transform> Points => _points;
    }
}