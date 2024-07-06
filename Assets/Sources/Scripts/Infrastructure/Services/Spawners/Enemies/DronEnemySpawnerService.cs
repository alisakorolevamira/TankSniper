using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Dron;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Dron;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies
{
    public class DronEnemySpawnerService : IDronEnemySpawnerService
    {
        private readonly DronEnemyViewFactory _viewFactory;

        public DronEnemySpawnerService(DronEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IDronEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, DronEnemyView view)
        {
            DronEnemy enemy = new DronEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.TankDamage));

            IDronEnemyView dronEnemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return dronEnemyView;
        }
    }
}