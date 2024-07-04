using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class TankEnemySpawnerService : ITankEnemySpawnerService
    {
        private readonly ITankEnemyViewFactory _viewFactory;

        public TankEnemySpawnerService(
            ITankEnemyViewFactory viewFactory)
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