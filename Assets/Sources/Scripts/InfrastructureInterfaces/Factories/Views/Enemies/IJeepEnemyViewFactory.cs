using Sources.Scripts.Domain.Models.Enemies.Jeep;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IJeepEnemyViewFactory
    {
        IJeepEnemyView Create(
            JeepEnemy tankEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            JeepEnemyView view);
    }
}