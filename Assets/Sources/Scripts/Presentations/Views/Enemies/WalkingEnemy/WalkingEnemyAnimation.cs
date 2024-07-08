using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy
{
    public class WalkingEnemyAnimation : View, IWalkingEnemyAnimation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _gunShoot;

        public void PlayIdle() => 
            _animator.Play("Walk");

        public void PlayAttack()
        {
            _animator.SetBool("Shoot", true);
            _gunShoot.Play();
        }

        public void PlayDying() => 
            Hide();
    }
}