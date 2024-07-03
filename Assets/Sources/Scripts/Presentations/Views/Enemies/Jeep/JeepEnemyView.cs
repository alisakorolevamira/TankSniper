using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Jeep
{
    public class JeepEnemyView : EnemyViewBase, IJeepEnemyView
    {
        [SerializeField] private JeepEnemyAnimation _enemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;
        
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
        public IJeepEnemyAnimation EnemyAnimation => _enemyAnimation;
        public Vector3 Position => transform.position;
        
        public void MoveToPoint(Vector3 direction) => 
            transform.position = Vector3.MoveTowards(transform.position, direction, 6 * Time.deltaTime);

        public void SetRotation(float angle) => 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);
    }
}