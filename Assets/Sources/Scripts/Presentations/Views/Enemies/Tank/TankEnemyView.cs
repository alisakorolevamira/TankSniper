using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyView : EnemyViewBase, ITankEnemyView
    {
        [SerializeField] private TankEnemyAnimation _enemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;

        public ITankEnemyAnimation EnemyAnimation => _enemyAnimation;
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
       
       public Vector3 Position => transform.position;
        
       public void MoveToPoint(Vector3 direction) => 
           transform.position = Vector3.MoveTowards(transform.position, direction, 1 * Time.deltaTime);

       public void SetRotation(float angle) => 
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);
    }
}