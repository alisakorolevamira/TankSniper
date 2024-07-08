using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boat
{
    public class BoatEnemyView : MovingEnemyViewBase, IBoatEnemyView
    {
        [SerializeField] private BoatEnemyAnimation _enemyAnimation;
        
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}