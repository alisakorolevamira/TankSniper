using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyView : EnemyViewBase, ITankEnemyView
    {
        [SerializeField] private TankEnemyAnimation _enemyAnimation;

        public TankEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}