using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopter
{
    public interface IHelicopterEnemySpawnerService
    {
        IHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, HelicopterEnemyView view);
    }
}