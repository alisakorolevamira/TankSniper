using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnPoint : View, IEnemySpawnPoint
    {
        [SerializeField] private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;

        public Vector3 Position => transform.position;
    }
}