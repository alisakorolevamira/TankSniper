using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tank;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies
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
            TankEnemy tank = new TankEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.TankDamage));

            ITankEnemyView tankEnemyView = _viewFactory.Create(tank, killedEnemiesCounter, view);

            return tankEnemyView;
        }
    }
}