using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Jeep
{
    public class JeepEnemyView : MovingEnemyViewBase, IJeepEnemyView
    {
        [SerializeField] private JeepEnemyAnimation _enemyAnimation;
        [SerializeField] private Transform _firstStanding;
        [SerializeField] private Transform _secondStanding;
        
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;

        public void RotateStandings()
        {
            _firstStanding.LookAt(PlayerHealthView.Position);
            _secondStanding.LookAt(PlayerHealthView.Position);
        }
    }
}