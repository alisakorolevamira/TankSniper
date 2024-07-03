using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyView : EnemyViewBase, IHelicopterEnemyView
    {
        [SerializeField] private HelicopterEnemyAnimation _enemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;
        [SerializeField] private float _speed = 1;
        [SerializeField] private Transform _rotar;
        [SerializeField] private float _rotationRotar = 1;
        
        public HelicopterEnemyAnimation EnemyAnimation => _enemyAnimation;
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
        public Vector3 Position => transform.position;

        public void MoveToPoint(Vector3 direction) => 
            transform.position = Vector3.MoveTowards(transform.position, direction, _speed * Time.deltaTime);

        public void SetRotation(float angle) => 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);

        public void RotateRotor() => 
            _rotar.Rotate(new Vector3(0,_rotationRotar,0));
    }
}