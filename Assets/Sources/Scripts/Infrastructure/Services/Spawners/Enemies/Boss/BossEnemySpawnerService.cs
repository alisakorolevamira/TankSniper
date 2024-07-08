﻿using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boss;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boss;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Boss
{
    public class BossEnemySpawnerService : IBossEnemySpawnerService
    {
        private readonly BossEnemyViewFactory _bossEnemyViewFactory;

        public BossEnemySpawnerService(BossEnemyViewFactory bossEnemyViewFactory)
        {
            _bossEnemyViewFactory = bossEnemyViewFactory
                                    ?? throw new ArgumentNullException(nameof(bossEnemyViewFactory));
        }

        public IBossEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, BossEnemyView view)
        {
            BossEnemy bossEnemy =
                new BossEnemy(new EnemyHealth(EnemyConst.BossHealth), new EnemyAttacker(EnemyConst.BossDamage));
            
            IBossEnemyView bossEnemyView = _bossEnemyViewFactory.Create(bossEnemy, killedEnemiesCounter, view);

            return bossEnemyView;
        }
    }
}