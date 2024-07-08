using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tanks
{
    public class StandingTankEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;
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
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}