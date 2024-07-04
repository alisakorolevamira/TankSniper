using System;
using JetBrains.Annotations;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyAnimation : View, IBossEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementParticle;
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        [SerializeField] private Animator _animator;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            _animator.Play("Move");
        }

        public void PlayAttack()
        {
            
        }

        public void PlayDying()
        {
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}