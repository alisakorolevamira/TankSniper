using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters
{
    public interface IBazookaHelicopterEnemyView : IMovingEnemyViewBase
    {
        IEnemyAnimation EnemyAnimation { get; }
        void RotateRotor();
    }
}