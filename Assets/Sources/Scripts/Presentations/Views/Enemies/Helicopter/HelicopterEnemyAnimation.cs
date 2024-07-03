using System;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyAnimation : View, IHelicopterEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Animator _bazookaAnimator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _enemy;
        
        public event Action Attacking;

        public void PlayIdle()
        {
            _bazookaAnimator.Play("Idle");
        }

        public void PlayAttack()
        {
            Attacking?.Invoke();
            
            _bazookaAnimator.SetBool("Shoot", true);
            _gunShoot.Play();
        }

        public void PlayDying()
        {
            _gunShoot.Stop();
            _rigidbody.isKinematic = false;
            Destroy(_enemy);
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}