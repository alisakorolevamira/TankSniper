using System;
using JetBrains.Annotations;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Presentations.Views.Enemies.Standing
{
    public class StandingEnemyAnimation : AnimationViewBase, IStandingEnemyAnimation
    {
        public event Action Attacking;
        
        private void Awake()
        {
            //StoppingAnimations.Add(StopIdle);
            //StoppingAnimations.Add(StopAttack);
        }

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
        }

        public void PlayDying()
        {
            Animator.SetBool("Dying", true);
        }

        private void StopIdle()
        {
        }

        private void StopAttack()
        {
        }
    }
}