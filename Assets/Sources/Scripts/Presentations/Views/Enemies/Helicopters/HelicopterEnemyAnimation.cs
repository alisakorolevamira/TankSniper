using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopters
{
    public class HelicopterEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        
        public void PlayIdle()
        {
        }

        public void PlayAttack()
        {
            _gunShoot.Play();
        }

        public void PlayDying()
        {
            _gunShoot.Stop();
            _rigidbody.isKinematic = false;
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}