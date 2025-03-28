﻿using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Bosses
{
    public class RobotRobotBossEnemySpawnerService : IRobotBossEnemySpawnerService
    {
        private readonly RobotBossEnemyViewFactory _viewFactory;

        public RobotRobotBossEnemySpawnerService(RobotBossEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IRobotBossEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, RobotBossEnemyView view)
        {
            Enemy bossEnemy = new Enemy(
                new EnemyHealth(EnemyConst.BossHealth), new EnemyAttacker(EnemyConst.RobotBossDamage));
            IRobotBossEnemyView enemyView = _viewFactory.Create(bossEnemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}