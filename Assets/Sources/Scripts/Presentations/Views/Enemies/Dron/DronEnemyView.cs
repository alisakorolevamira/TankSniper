using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Dron
{
    public class DronEnemyView : MovingEnemyViewBase, IDronEnemyView
    {
        [SerializeField] private DronEnemyAnimation _enemyAnimation;
        
        public IDronEnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}