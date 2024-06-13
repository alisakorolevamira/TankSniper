using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface ITankEnemyViewFactory
    {
        ITankEnemyView Create(TankEnemy tankEnemy, KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint);
    }
}