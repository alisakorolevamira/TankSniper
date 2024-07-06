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
    public class HelicopterEnemyView : MovingEnemyViewBase, IHelicopterEnemyView
    {
        [SerializeField] private HelicopterEnemyAnimation _enemyAnimation;
        [SerializeField] private Transform _rotar;
        [SerializeField] private float _rotationRotar = 1;
        
        public HelicopterEnemyAnimation EnemyAnimation => _enemyAnimation;

        public void RotateRotor() => 
            _rotar.Rotate(new Vector3(0,_rotationRotar,0));
    }
}