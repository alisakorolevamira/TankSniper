using System;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Players
{
    public interface IPlayerAttackService
    {
        bool PlayerAttacked { get; }
        void Attack();
    }
}