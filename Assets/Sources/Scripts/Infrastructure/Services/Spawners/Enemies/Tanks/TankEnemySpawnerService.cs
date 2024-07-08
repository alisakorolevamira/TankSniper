using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tanks;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Tanks
{
    public class TankEnemySpawnerService : ITankEnemySpawnerService
    {
        private readonly TankEnemyViewFactory _viewFactory;

        public TankEnemySpawnerService(TankEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public ITankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, TankEnemyView view)
        {
            Enemy tank = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.TankDamage));
            ITankEnemyView enemyView = _viewFactory.Create(tank, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}