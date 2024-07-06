using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing
{
    public interface IStandingEnemyView : IEnemyViewBase
    {
        StandingEnemyAnimation EnemyAnimation { get; }
    }
}