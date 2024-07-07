using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy
{
    public class WalkingEnemyView : MovingEnemyViewBase, IWalkingEnemyView
    {
        [SerializeField] private WalkingEnemyAnimation _enemyAnimation;

        public WalkingEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}