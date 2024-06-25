using System;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Players
{
    public interface IPlayerAttackService
    {
        event Action DoubleAttackEnabled;
        bool PlayerAttacked { get; }
        void Attack();
        void EnableDoubleAttack();
    }
}