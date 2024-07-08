using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks
{
    public interface IStandingTankEnemyView : IEnemyViewBase
    {
        IEnemyAnimation EnemyAnimation { get; }
    }
}