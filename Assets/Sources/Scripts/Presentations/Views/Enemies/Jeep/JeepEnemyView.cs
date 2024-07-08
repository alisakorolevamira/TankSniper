using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Jeep
{
    public class JeepEnemyView : MovingEnemyViewBase, IJeepEnemyView
    {
        [SerializeField] private JeepEnemyAnimation _enemyAnimation;
        
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}