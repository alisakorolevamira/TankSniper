using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Scripts
{
    public class TestAnimation : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        
        public bool IsDestroyed = false;

        private void OnEnable()
        {
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}