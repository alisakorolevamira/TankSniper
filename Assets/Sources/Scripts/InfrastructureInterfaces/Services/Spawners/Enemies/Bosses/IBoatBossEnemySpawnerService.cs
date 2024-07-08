using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses
{
    public interface IBoatBossEnemySpawnerService
    {
        IBoatBossEnemyView Spawn(KilledEnemiesCounter killEnemyCounter, BoatBossEnemyView view);
    }
}