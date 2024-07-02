using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyView : EnemyViewBase, ITankEnemyView
    {
        [SerializeField] private TankEnemyAnimation _enemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;

        public TankEnemyAnimation EnemyAnimation => _enemyAnimation;
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
    }
}