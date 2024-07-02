using System;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyAnimation : AnimationViewBase, ITankEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementParticle;
        [SerializeField] private ParticleSystem _attackParticle;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            _movementParticle.Play();
        }

        public void PlayAttack()
        {
            _movementParticle.Stop();
            _attackParticle.Play();
            Attacking?.Invoke();
        }

        public void PlayDying()
        {
            
        }
    }
}