using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Dron
{
    public class DronEnemyAnimation : View, IDronEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        [SerializeField] private List<Rigidbody> _rigidbodies;

        public void PlayIdle()
        {
            foreach (Rigidbody rigidbody in _rigidbodies) 
                rigidbody.isKinematic = true;
        }

        public void PlayAttack() => 
            _attackParticle.Play();

        public void PlayDying()
        {
            _attackParticle.Stop();
            
            foreach (Rigidbody rigidbody in _rigidbodies) 
                rigidbody.isKinematic = false;
            
            Destroy(gameObject);
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}