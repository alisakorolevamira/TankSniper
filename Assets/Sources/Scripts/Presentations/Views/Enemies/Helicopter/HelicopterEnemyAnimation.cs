using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyAnimation : View, IHelicopterEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Animator _bazookaAnimator;
        [SerializeField] private List<Rigidbody> _rigidbodies;
        [SerializeField] private Collider _collider;
        //[SerializeField] private GameObject _enemy;

        public void PlayIdle()
        {
            foreach (Rigidbody rigidbody in _rigidbodies) 
                rigidbody.isKinematic = true;
            
            _bazookaAnimator.Play("Idle");
        }

        public void PlayAttack()
        {
            _bazookaAnimator.SetBool("Shoot", true);
            _gunShoot.Play();
        }

        public void PlayDying()
        {
            _gunShoot.Stop();
            
            foreach (Rigidbody rigidbody in _rigidbodies) 
                rigidbody.isKinematic = true;
            
            Destroy(gameObject);
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}