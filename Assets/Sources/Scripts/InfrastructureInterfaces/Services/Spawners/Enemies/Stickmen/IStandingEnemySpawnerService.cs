using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen
{
    public interface IStandingEnemySpawnerService
    {
        IStandingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, StandingEnemyView view);
    }
}