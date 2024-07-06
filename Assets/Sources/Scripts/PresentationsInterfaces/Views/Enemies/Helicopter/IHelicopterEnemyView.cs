using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter
{
    public interface IHelicopterEnemyView : IMovingEnemyViewBase
    {
        HelicopterEnemyAnimation EnemyAnimation { get; }
        void RotateRotor();
    }
}