using System;
using JetBrains.Annotations;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public class EnemyAnimation : AnimationViewBase, IEnemyAnimation
    {
        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isWalk = Animator.StringToHash("IsWalk");
        private static int s_isAttack = Animator.StringToHash("IsAttack");

        public event Action Attacking;

        private void Awake()
        {

        }

        public void PlayWalk()
        {

        }

        public void PlayIdle()
        {

        }

        public void PlayAttack()
        {

        }

        public void PlayDying()
        {
            
        }

        protected virtual void OnAfterAwake()
        {
        }
    }
}