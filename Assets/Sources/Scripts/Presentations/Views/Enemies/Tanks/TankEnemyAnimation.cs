using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tanks
{
    public class TankEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementParticle;
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private Collider _collider;
        
        public void PlayIdle() => 
            _movementParticle.Play();

        public void PlayAttack()
        {
            _movementParticle.Stop();
            _attackParticle.Play();
        }

        public void PlayDying()
        {
            _attackParticle.Stop();
            _movementParticle.Stop();
            
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
            //Hide();
        }
    }
}