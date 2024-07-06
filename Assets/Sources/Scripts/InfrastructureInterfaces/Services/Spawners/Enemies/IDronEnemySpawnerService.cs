using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies
{
    public interface IDronEnemySpawnerService
    {
        IDronEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, DronEnemyView view);
    }
}