using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Standing
{
    public class StandingEnemyView : EnemyViewBase, IStandingEnemyView
    {
        [SerializeField] private StandingEnemyAnimation _enemyAnimation;

        public StandingEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}