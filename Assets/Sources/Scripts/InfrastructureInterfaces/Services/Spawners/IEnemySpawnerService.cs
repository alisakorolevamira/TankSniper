using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IEnemySpawnerService
    {
        IEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, Vector3 position);
    }
}