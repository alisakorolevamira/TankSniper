using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Scripts
{
    public class TestAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Collider _collider;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(RemoveMesh);
        }

        private void RemoveMesh()
        {
            _gameObject.SetActive(true);
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
}