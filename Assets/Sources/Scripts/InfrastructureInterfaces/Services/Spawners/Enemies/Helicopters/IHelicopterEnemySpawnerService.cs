using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Helicopters;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopters
{
    public interface IHelicopterEnemySpawnerService
    {
        IHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, HelicopterEnemyView view);
    }
}