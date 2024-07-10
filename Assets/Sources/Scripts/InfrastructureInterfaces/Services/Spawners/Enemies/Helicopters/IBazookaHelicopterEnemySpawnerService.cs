using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Helicopters;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopters
{
    public interface IBazookaHelicopterEnemySpawnerService
    {
        IBazookaHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, BazookaHelicopterEnemyView view);
    }
}