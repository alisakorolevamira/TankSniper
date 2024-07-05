using System;
using JetBrains.Annotations;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyAnimation : View, IBossEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Animator _animator;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            _attackParticle.Stop();
            _animator.SetBool("Walk", true);
        }

        public void PlayAttack()
        {
            _animator.SetBool("Walk", false);
            _attackParticle.Play();
        }

        public void PlayDying()
        {
            _animator.enabled = false;
        }
    }
}