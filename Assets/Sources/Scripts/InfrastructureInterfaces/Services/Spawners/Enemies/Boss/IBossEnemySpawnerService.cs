using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boss
{
    public interface IBossEnemySpawnerService
    {
        IBossEnemyView Spawn(KilledEnemiesCounter killEnemyCounter, BossEnemyView view);
    }
}