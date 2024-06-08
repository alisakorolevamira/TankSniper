using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.DomainInterfaces.Models.Players;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players
{
    public class PlayerHealth : IHealth, IPlayerHealth
    {
        private float _currentHealth;

        public PlayerHealth()
        {
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        public event Action<float> DamageReceived;
        public event Action PlayerDie;

        public float MaxHealth => PlayerConst.MaxHealth;
        public bool IsDied { get; private set; }

        public float CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                HealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth <= 0)
                return;
            
            CurrentHealth -= damage;
            DamageReceived?.Invoke(damage);

            if (CurrentHealth > 0)
                return;

            IsDied = true;
            PlayerDie?.Invoke();
        }
    }
}