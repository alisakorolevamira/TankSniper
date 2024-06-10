using System;
using JetBrains.Annotations;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyAnimation : EnemyAnimation, IBossEnemyAnimation
    {
        private static int s_isRun = Animator.StringToHash("IsRun");

        public event Action ScreamAnimationEnded;

        public void PlayRun()
        {
            ExceptAnimation(StopRun);
            Animator.SetBool(s_isRun, true);
        }

        protected override void OnAfterAwake() =>
            StoppingAnimations.Add(StopRun);

        private void StopRun()
        {
            if (Animator.GetBool(s_isRun) == false)
                return;

            Animator.SetBool(s_isRun, false);
        }

        [UsedImplicitly]
        private void OnScreamAnimationEnded() =>
            ScreamAnimationEnded?.Invoke();
    }
}