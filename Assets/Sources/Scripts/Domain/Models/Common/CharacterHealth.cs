using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.DomainInterfaces.Models.Common;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Common
{
    public class CharacterHealth : IHealth, ICharacterHealth
    {
        private float _currentHealth;

        public CharacterHealth()
        {
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        public event Action<float> DamageReceived;
        public event Action Die;

        public float MaxHealth => PlayerConst.MaxHealth;
        public bool IsDied { get; private set; }

        public float CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                _currentHealth = Mathf.Clamp(value, PlayerConst.MinHealth, MaxHealth);
                HealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth <= PlayerConst.MinHealth)
                return;
            
            CurrentHealth -= damage;
            DamageReceived?.Invoke(damage);

            if (CurrentHealth > PlayerConst.MinHealth)
                return;

            IsDied = true;
            Die?.Invoke();
        }
    }
}