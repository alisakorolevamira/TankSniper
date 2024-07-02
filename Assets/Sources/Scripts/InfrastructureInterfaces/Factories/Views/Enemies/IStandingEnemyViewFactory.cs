using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IStandingEnemyViewFactory
    {
        IStandingEnemyView Create(
            StandingEnemy tankEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            EnemyViewBase enemyViewBase);
    }
}