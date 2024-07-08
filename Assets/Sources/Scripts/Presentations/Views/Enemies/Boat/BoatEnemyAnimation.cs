using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boat
{
    public class BoatEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _enemy;
        [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private Animator _animator;
        
        public void PlayIdle()
        {
            _animator.SetBool("Shoot", false);
            _shootEffect.Stop();
        }

        public void PlayAttack()
        {
            _animator.SetBool("Shoot", true);
            _shootEffect.Play();
        }

        public void PlayDying()
        {
            _shootEffect.Stop();
            //Hide();
            Destroy(_enemy);
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}