using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class BossEnemySpawnerService : IBossEnemySpawnerService
    {
        private readonly IBossEnemyViewFactory _bossEnemyViewFactory;

        public BossEnemySpawnerService(
            IBossEnemyViewFactory bossEnemyViewFactory)
        {
            _bossEnemyViewFactory = bossEnemyViewFactory
                                    ?? throw new ArgumentNullException(nameof(bossEnemyViewFactory));
        }

        public IBossEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, Vector3 position)
        {
            BossEnemy bossEnemy = new BossEnemy(
                new EnemyHealth(BossEnemyConst.Health),
                new EnemyAttacker(BossEnemyConst.Damage),
                BossEnemyConst.StunTime,
                BossEnemyConst.WalkSpeed,
                BossEnemyConst.RunSpeed);
            
            IBossEnemyView bossEnemyView = _bossEnemyViewFactory.Create(bossEnemy, killedEnemiesCounter);
            bossEnemyView.DisableNavmeshAgent();
            bossEnemyView.SetPosition(position);
            bossEnemyView.EnableNavmeshAgent();
            bossEnemyView.Show();

            return bossEnemyView;
        }

       // private IBossEnemyView SpawnFromPool(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter)
       // {
       //     BossEnemyView enemyView = _bossEnemyPool.Get<BossEnemyView>();
//
       //     if (enemyView == null)
       //         return null;
//
       //     return _bossEnemyViewFactory.Create(bossEnemy, killedEnemiesCounter, enemyView);
       // }
    }
}