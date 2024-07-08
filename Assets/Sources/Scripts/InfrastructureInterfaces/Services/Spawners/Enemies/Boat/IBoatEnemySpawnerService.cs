using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boat
{
    public interface IBoatEnemySpawnerService
    {
        IBoatEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, BoatEnemyView view);
    }
}