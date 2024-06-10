using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IBossEnemyViewFactory
    {
        IBossEnemyView Create(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter);

        IBossEnemyView Create(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter, BossEnemyView bossEnemyView);
    }
}