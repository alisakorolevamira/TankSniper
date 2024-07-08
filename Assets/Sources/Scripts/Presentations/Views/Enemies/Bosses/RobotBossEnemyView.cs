using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Presentations.Views.BossPeaces;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Bosses
{
    public class RobotBossEnemyView : MovingEnemyViewBase, IRobotBossEnemyView
    {
        [SerializeField] private RobotBossEnemyAnimation _robotBossEnemyAnimation;
        [SerializeField] private List<BossPieceView> _peaces;
        [SerializeField] private HealthBarUI _healthBar;

        public IEnemyAnimation EnemyAnimation => _robotBossEnemyAnimation;
        public HealthBarUI HealthBar => _healthBar;

        public void Explode()
        {
            foreach (BossPieceView peace in _peaces)
            {
                if (peace.IsDestroyed == false) 
                    peace.Explode();
            }
            
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IBulletView bulletView))
            {
                BossPieceView piece = _peaces.First(p => p.IsDestroyed == false);
                piece.Explode();
            }
        }
    }
}