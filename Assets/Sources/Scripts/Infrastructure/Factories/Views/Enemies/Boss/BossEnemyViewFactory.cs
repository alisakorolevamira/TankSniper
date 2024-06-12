using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boss
{
    public class BossEnemyViewFactory : IBossEnemyViewFactory
    {
        private readonly BossEnemyPresenterFactory _bossEnemyPresenterFactory;
        //private readonly IObjectPool<BossEnemyView> _bossEnemyPool;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;


        public IBossEnemyView Create(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter)
        {
            throw new NotImplementedException();
        }

        public IBossEnemyView Create(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter, BossEnemyView bossEnemyView)
        {
            throw new NotImplementedException();
        }
    }
}