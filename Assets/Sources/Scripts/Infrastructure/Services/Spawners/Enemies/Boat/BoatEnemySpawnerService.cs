using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boat;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boat;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Boat
{
    public class BoatEnemySpawnerService : IBoatEnemySpawnerService
    {
        private readonly BoatEnemyViewFactory _viewFactory;

        public BoatEnemySpawnerService(BoatEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IBoatEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, BoatEnemyView view)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.BoatDamage));
            IBoatEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}