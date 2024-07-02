using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyAnimation : AnimationViewBase, ITankEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementParticle;
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        
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
            _attackParticle.Stop();
            _movementParticle.Stop();
            
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}