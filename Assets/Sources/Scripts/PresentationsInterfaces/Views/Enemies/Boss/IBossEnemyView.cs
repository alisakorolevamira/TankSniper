using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IMovingEnemyViewBase
    {
        BossEnemyAnimation EnemyAnimation { get; }
        HealthBarUI HealthBar { get; }
        
        void Explode();
    }
}