using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Animator _bazookaAnimator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _enemy;

        public void PlayIdle()
        {
            _rigidbody.isKinematic = true;
            
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
            _bazookaAnimator.SetBool("Shoot", false);
            Destroy(_enemy);
            
            _rigidbody.isKinematic = false;
            
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}