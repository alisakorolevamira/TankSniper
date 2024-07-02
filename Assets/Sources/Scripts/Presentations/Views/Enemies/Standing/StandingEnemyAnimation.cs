using System;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Standing
{
    public class StandingEnemyAnimation : AnimationViewBase, IStandingEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        
        public event Action Attacking;

        public void PlayIdle()
        {
            ExceptAnimation(StopIdle);
            //Animator.SetBool(s_isIdle, true);
            Animator.Play("Idle");
        }

        public void PlayAttack()
        {
            Attacking?.Invoke();
            ExceptAnimation(StopAttack);
            //Animator.SetBool(s_isAttack, true);
            Animator.SetBool("Shoot", true);
            //_gunShoot.Play();
        }

        public void PlayDying() => 
            Hide();

        private void StopIdle()
        {
        }

        private void StopAttack()
        {
        }
    }
}