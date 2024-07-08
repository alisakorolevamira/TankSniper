using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen
{
    public interface IWalkingEnemySpawnerService
    {
        IWalkingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, WalkingEnemyView view);
    }
}