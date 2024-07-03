using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Jeep;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class JeepEnemySpawnerService : IJeepEnemySpawnerService
    {
        private readonly IJeepEnemyViewFactory _viewFactory;

        public JeepEnemySpawnerService(IJeepEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IJeepEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, JeepEnemyView view)
        {
            JeepEnemy enemy = new JeepEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.StandingDamage));
            IJeepEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}