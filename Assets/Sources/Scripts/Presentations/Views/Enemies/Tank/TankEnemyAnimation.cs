using System;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyAnimation : EnemyAnimation, ITankEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementAnimation;
        [SerializeField] private ParticleSystem _attackParticle;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            _movementAnimation.Play();
        }

        public void PlayAttack()
        {
            _movementAnimation.Stop();
            _attackParticle.Play();
            Attacking?.Invoke();
        }
    }
}