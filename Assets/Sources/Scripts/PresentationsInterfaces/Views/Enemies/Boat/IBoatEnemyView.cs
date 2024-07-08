using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat
{
    public interface IBoatEnemyView : IMovingEnemyViewBase
    {
        IEnemyAnimation EnemyAnimation { get; }
    }
}