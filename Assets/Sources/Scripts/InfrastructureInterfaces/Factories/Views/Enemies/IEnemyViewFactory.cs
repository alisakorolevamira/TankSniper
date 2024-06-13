using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IEnemyViewFactory
    {
        public ITankEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint);

        public ITankEnemyView Create(Enemy enemy, 
            KilledEnemiesCounter killedEnemiesCounter,
            TankTankEnemyView tankTankEnemyView,
            IEnemySpawnPoint spawnPoint);
    }
}