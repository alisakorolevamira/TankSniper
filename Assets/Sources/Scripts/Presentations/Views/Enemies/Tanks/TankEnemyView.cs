using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tanks
{
    public class TankEnemyView : MovingEnemyViewBase, ITankEnemyView
    {
        [SerializeField] private TankEnemyAnimation _enemyAnimation;

        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}