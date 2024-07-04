using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IBossEnemySpawnerService
    {
        IBossEnemyView Spawn(KilledEnemiesCounter killEnemyCounter, BossEnemyView view);
    }
}