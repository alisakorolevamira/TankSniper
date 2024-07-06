using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public class MovingEnemyViewBase : EnemyViewBase, IMovingEnemyViewBase
    {
        [SerializeField] private List<Transform> _movementPoints;
        [SerializeField] private float _speed;
        
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
        public Vector3 Position => transform.position;
        
        public void MoveToPoint(Vector3 direction) => 
            transform.position = Vector3.MoveTowards(transform.position, direction, _speed * Time.deltaTime);

        public void SetRotation(float angle) => 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);
    }
}