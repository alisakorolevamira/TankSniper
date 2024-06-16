using System;
using DestroyIt;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyAnimation : AnimationViewBase, IHelicopterEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Destructible _destructible; 
        
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
            _gunShoot.Play();
        }

        public void PlayDying()
        {
            _destructible.Destroy();
        }

        private void StopIdle()
        {
        }

        private void StopAttack()
        {
        }
    }
}