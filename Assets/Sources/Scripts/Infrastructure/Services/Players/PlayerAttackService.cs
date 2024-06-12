using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Services.Players
{
    public class PlayerAttackService : IPlayerAttackService
    {
        public bool PlayerAttacked { get; private set; }
        
        public void Attack()
        {
            PlayerAttacked = true;
        }
    }
}