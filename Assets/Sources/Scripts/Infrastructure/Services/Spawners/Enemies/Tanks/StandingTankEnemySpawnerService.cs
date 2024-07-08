using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Tanks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tanks;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Tanks
{
    public class StandingTankEnemySpawnerService : IStandingTankEnemySpawnerService
    {
        private readonly StandingTankEnemyViewFactory _viewFactory;

        public StandingTankEnemySpawnerService(StandingTankEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IStandingTankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, StandingTankEnemyView view)
        {
            Enemy tank = new Enemy(
                new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.StandingTankDamage));
            IStandingTankEnemyView enemyView = _viewFactory.Create(tank, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}