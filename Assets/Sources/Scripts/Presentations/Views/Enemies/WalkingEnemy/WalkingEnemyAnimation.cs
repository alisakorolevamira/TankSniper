using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy
{
    public class WalkingEnemyAnimation : View, IWalkingEnemyAnimation
    {
        [SerializeField] private Animator _animator;

        public void PlayIdle() => 
            _animator.Play("Move");

        public void PlayAttack()
        {
            _animator.SetBool("Shoot", true);
            //_gunShoot.Play();
        }

        public void PlayDying() => 
            Hide();
    }
}