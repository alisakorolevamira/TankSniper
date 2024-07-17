using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using UnityEngine;

namespace Sources.Scripts
{
    public class testbullet : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody _rigidbody;

        private bool _isDisposed;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(BulletConst.Delay);
        
        private void Start()
        {
            ChangePosition();
        }

        private void OnCollisionEnter(Collision other)
        {
            _isDisposed = true;
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        
        private async void ChangePosition()
        {
            float step =  30 * Time.deltaTime;
            
            try
            {
                while (_isDisposed == false)
                {
                    _rigidbody.velocity = transform.forward * 10;

                    await UniTask.Delay(_delay);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}