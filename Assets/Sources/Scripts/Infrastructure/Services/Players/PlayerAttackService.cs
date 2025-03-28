﻿using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;

namespace Sources.Scripts.Infrastructure.Services.Players
{
    public class PlayerAttackService : IPlayerAttackService
    {
        public event Action DoubleAttackEnabled;
        public bool PlayerAttacked { get; private set; }
        
        public void Attack() => 
            PlayerAttacked = true;

        public void EnableDoubleAttack() => 
            DoubleAttackEnabled?.Invoke();
    }
}