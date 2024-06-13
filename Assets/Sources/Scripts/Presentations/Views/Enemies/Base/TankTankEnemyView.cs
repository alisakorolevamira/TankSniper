using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public class TankTankEnemyView : EnemyViewBase, ITankEnemyView
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;

        public EnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}