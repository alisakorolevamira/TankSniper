using Sources.Scripts.Domain.Models.Enemies.Helicopter;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IHelicopterEnemyViewFactory
    {
        IHelicopterEnemyView Create(
            HelicopterEnemy tankEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            EnemyViewBase enemyViewBase);
    }
}