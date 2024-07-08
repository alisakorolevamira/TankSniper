using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Bosses
{
    public class BoatBossEnemySpawnerService : IBoatBossEnemySpawnerService
    {
        private readonly BoatBossEnemyViewFactory _viewFactory;

        public BoatBossEnemySpawnerService(BoatBossEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IBoatBossEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, BoatBossEnemyView view)
        {
            BossEnemy bossEnemy =
                new BossEnemy(new EnemyHealth(EnemyConst.BossHealth), new EnemyAttacker(EnemyConst.BoatBossDamage));
            
            IBoatBossEnemyView robotBossEnemyView = _viewFactory.Create(bossEnemy, killedEnemiesCounter, view);

            return robotBossEnemyView;
        }
    }
}