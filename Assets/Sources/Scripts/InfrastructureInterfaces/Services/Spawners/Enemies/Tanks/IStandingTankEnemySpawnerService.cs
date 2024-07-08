using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks
{
    public interface IStandingTankEnemySpawnerService
    {
        IStandingTankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, StandingTankEnemyView view);
    }
}