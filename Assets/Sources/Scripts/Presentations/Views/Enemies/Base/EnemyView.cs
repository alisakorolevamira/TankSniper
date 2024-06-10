using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public class EnemyView : EnemyViewBase, IEnemyView
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;

        public EnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}