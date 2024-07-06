using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep
{
    public interface IJeepEnemyView : IMovingEnemyViewBase
    {
        IJeepEnemyAnimation EnemyAnimation { get; }
    }
}