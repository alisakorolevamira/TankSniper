using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Bosses
{
    public class BoatBossEnemyView : EnemyViewBase, IBoatBossEnemyView
    {
        [SerializeField] private BoatBossEnemyAnimation _enemyAnimation;
        [SerializeField] private HealthBarUI _healthBar;

        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
        public HealthBarUI HealthBar => _healthBar;
    }
}