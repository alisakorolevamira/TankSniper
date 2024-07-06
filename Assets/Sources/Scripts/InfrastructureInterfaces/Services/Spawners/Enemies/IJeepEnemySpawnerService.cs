using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies
{
    public interface IJeepEnemySpawnerService
    {
        IJeepEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, JeepEnemyView view);
    }
}