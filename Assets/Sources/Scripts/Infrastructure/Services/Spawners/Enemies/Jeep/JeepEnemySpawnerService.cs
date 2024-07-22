using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Jeep;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Jeep
{
    public class JeepEnemySpawnerService : IJeepEnemySpawnerService
    {
        private readonly JeepEnemyViewFactory _viewFactory;

        public JeepEnemySpawnerService(JeepEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IJeepEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, JeepEnemyView view)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.JeepDamage));
            IJeepEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}