using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Bosses
{
    public class HelicopterBossEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;
        
        public void PlayIdle()
        {
            //_attackParticle.Stop();
        }

        public void PlayAttack()
        {
            //_attackParticle.Play();
        }

        public void PlayDying()
        {
            //_attackParticle.Stop();
            _rigidbody.isKinematic = false;
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
            Hide();
        }
    }
}