using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Dron
{
    public class DronEnemyView : MovingEnemyViewBase, IDronEnemyView
    {
        [SerializeField] private DronEnemyAnimation _enemyAnimation;
        [SerializeField] private List<Transform> _rotors;
        [SerializeField] private float _rotationRotor = 100;
        
        public IDronEnemyAnimation EnemyAnimation => _enemyAnimation;

        public void RotateRotors()
        {
            foreach (Transform rotor in _rotors) 
                rotor.Rotate(new Vector3(0,_rotationRotor,0));
        }
    }
}