using System;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Dron
{
    public class DronEnemyAnimation : AnimationViewBase, IDronEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
        }

        public void PlayAttack()
        {
            _attackParticle.Play();
            Attacking?.Invoke();
        }

        public void PlayDying()
        {
            _attackParticle.Stop();
            
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}