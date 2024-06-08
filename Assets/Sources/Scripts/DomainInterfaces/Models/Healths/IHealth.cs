using System;

namespace Sources.Scripts.DomainInterfaces.Models.Healths
{
    public interface IHealth
    {
        event Action HealthChanged;
        event Action<float> DamageReceived; 
        
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}