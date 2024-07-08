using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tanks
{
    public class StandingTankEnemyView : EnemyViewBase, IStandingTankEnemyView
    {
        [SerializeField] private StandingTankEnemyAnimation _enemyAnimation;

        public IStandingTankEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}