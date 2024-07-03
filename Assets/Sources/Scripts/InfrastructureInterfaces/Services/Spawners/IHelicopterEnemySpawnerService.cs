using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IHelicopterEnemySpawnerService
    {
        IHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, HelicopterEnemyView view);
    }
}