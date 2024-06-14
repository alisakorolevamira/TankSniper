using UnityEngine;

namespace Sources.Scripts
{
    public class BulletTest : MonoBehaviour
    {
        [Header("Common")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _damage = 10f;
        
        [Header("Effect On Destroy")]
        [SerializeField] private ParticleSystem _onDestroyEffect;
        [SerializeField] private bool _spawnEffectDestroy = true;
        [SerializeField] private float _effectDestroyLifetime = 2f;
        
        [Header("SecondRealization")]
        

        private bool _isBulletDespoysed;

        public Rigidbody Rigidbody => _rigidbody;
        public float Damage => _damage;

        private void OnCollisionEnter(Collision collision)
        {
            if(_isBulletDespoysed)
                return;

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                OnTargetCollision(collision, damageable);
                DisposeBullet();
            }
        }

        public void DisposeBullet()
        {
            //OnProjectileDispose();
            SpawnEffectOnDestroy();

            _isBulletDespoysed = true;
        }

        private void SpawnEffectOnDestroy()
        {
            if (_spawnEffectDestroy == false)
                return;

            //var effect = Instantiate(_onDestroyEffect, transform.position, Quaternion.identity);
            _onDestroyEffect.Play();
            
            Destroy(_onDestroyEffect.gameObject, _effectDestroyLifetime);
        }

        private void OnTargetCollision(Collision collision, IDamageable damageable)
        {
            damageable.ApplyDamage(10);
        }
    }
}