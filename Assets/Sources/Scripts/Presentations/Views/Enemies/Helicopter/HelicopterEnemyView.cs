using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyView : MovingEnemyViewBase, IHelicopterEnemyView
    {
        [SerializeField] private HelicopterEnemyAnimation _enemyAnimation;
        [SerializeField] private Transform _rotor;
        [SerializeField] private float _rotationRotor = 1;
        
        public HelicopterEnemyAnimation EnemyAnimation => _enemyAnimation;

        public void RotateRotor() => 
            _rotor.Rotate(new Vector3(0,_rotationRotor,0));
    }
}