using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyView : EnemyViewBase, IBossEnemyView
    {
        [SerializeField] private BossEnemyAnimation _bossEnemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;

        public BossEnemyAnimation EnemyAnimation => _bossEnemyAnimation;
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
        public Vector3 Position => transform.position;
        
        public void MoveToPoint(Vector3 direction) => 
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.2f * Time.deltaTime);

        public void SetRotation(float angle) => 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);
    }
}