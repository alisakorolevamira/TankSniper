using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class EnemySpawnerService : IEnemySpawnerService
    {
        //private readonly IObjectPool<EnemyView> _enemyPool;
        private readonly IEnemyViewFactory _enemyViewFactory;

        public EnemySpawnerService(
            //IObjectPool<EnemyView> enemyPool,
            IEnemyViewFactory enemyViewFactory)
        {
            //_enemyPool = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
        }

        public IEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, Vector3 position)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.Damage));

            IEnemyView enemyView = _enemyViewFactory.Create(enemy, killedEnemiesCounter);

            enemyView.DisableNavmeshAgent();
            enemyView.SetPosition(position);
            enemyView.EnableNavmeshAgent();
            enemyView.Show();

            return enemyView;
        }

        //private IEnemyView SpawnFromPool(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter)
        //{
        //    EnemyView enemyView = _enemyPool.Get<EnemyView>();
//
        //    if (enemyView == null)
        //        return null;
//
        //    return _enemyViewFactory.Create(enemy, killedEnemiesCounter, enemyView);
        //}
    }
}