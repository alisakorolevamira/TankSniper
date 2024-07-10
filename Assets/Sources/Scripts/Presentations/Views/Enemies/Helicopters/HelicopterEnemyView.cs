using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopters
{
    public class HelicopterEnemyView : EnemyViewBase, IHelicopterEnemyView
    {
        [SerializeField] private HelicopterEnemyAnimation _enemyAnimation;
        [SerializeField] private Transform _rotor;
        [SerializeField] private float _rotationRotor = 1;
        
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;

        public void RotateRotor() => 
            _rotor.Rotate(new Vector3(0,_rotationRotor,0));
    }
}