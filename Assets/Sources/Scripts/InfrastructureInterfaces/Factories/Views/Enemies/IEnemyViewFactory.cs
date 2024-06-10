using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IEnemyViewFactory
    {
        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter);

        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, EnemyView enemyView);
    }
}