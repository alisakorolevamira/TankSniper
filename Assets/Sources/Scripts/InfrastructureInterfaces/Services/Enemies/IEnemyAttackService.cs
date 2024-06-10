using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Enemies
{
    public interface IEnemyAttackService
    {
        void TryAttack(Vector3 position, int damage);
    }
}