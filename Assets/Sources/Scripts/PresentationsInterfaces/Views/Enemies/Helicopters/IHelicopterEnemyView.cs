using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters
{
    public interface IHelicopterEnemyView : IEnemyViewBase
    {
        IEnemyAnimation EnemyAnimation { get; }
        void RotateRotor();
    }
}