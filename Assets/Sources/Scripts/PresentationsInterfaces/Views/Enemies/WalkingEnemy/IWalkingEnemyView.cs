using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy
{
    public interface IWalkingEnemyView : IMovingEnemyViewBase
    {
        WalkingEnemyAnimation EnemyAnimation { get; }
    }
}