using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Standing
{
    public class StandingEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Animator _animator;

        public void PlayIdle() => 
            _animator.Play("Idle");

        public void PlayAttack()
        {
            _animator.SetBool("Shoot", true);
            _gunShoot.Play();
        }

        public void PlayDying() => 
            Hide();
    }
}