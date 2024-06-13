using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnPoint : View, IEnemySpawnPoint
    {
        [FormerlySerializedAs("tankEnemyView")] [FormerlySerializedAs("_enemyView")] [SerializeField] private TankTankEnemyView tankTankEnemyView;
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private List<Transform> _points;

        public TankTankEnemyView TankTankEnemyView => tankTankEnemyView;
        public EnemyType EnemyType => _enemyType;
        public Vector3 Position => transform.position;
        public IReadOnlyList<Transform> Points => _points;
    }
}