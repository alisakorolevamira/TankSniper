using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyAnimation : View, IBossEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Animator _animator;
        
        public void PlayIdle()
        {
            _animator.SetBool("Walk", true);
            _attackParticle.Stop();
        }

        public void PlayAttack()
        {
            _animator.SetBool("Walk", false);
            _attackParticle.Play();
        }

        public void PlayDying() => 
            _animator.SetBool("Walk", false);
    }
}