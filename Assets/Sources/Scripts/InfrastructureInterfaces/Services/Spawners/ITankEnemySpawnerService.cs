using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface ITankEnemySpawnerService
    {
        ITankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, TankEnemyView view);
    }
}