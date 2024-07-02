using System;
using Cysharp.Threading.Tasks;
using ShatterToolkit;
using ShatterToolkit.Helpers;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyAnimation : AnimationViewBase, IHelicopterEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Animator _bazookaAnimator;
        [SerializeField] private ShatterOnCollision _shatterTool;
        [SerializeField] private Rigidbody _rigidbody;
        
        private static int s_isIdle = Animator.StringToHash("IsIdle");
        private static int s_isAttack = Animator.StringToHash("IsAttack");
        
        public event Action Attacking;

        public void PlayIdle()
        {
            //Animator.Play("Idle");
            _bazookaAnimator.Play("Idle");
        }

        public void PlayAttack()
        {
            Attacking?.Invoke();
            
            //Animator.SetBool("Shoot", true);
            //Animator.Play("Attack");
            _bazookaAnimator.SetBool("Shoot", true);
            _gunShoot.Play();
        }

        public void PlayDying()
        {
            Debug.Log("die anim");
            Animator.SetBool("Die", true);
            _gunShoot.Stop();
            _shatterTool.enabled = true;
            _rigidbody.isKinematic = false;
            //_shatterTool.Shatter(transform.position);
        }
    }
}