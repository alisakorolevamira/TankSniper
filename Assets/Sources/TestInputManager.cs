using System;
using UnityEngine;

namespace Sources
{
    public class TestInputManager : MonoBehaviour
    {
        public event Action<Vector2> RotationInputReceived;
        private InputMap _inputMap;
        private InputService _inputService;

        private void Awake()
        {
            _inputMap = new ();
        
            _inputMap.Enable();
            InitTouchscreenInput(_inputMap);
        }

        private void InitTouchscreenInput(InputMap inputMap)
        {
            _inputService = new(inputMap);

            _inputService.RotationInputReceived += OnRotationInputReceived;
        }

        private void OnRotationInputReceived(Vector2 delta)
        {
            RotationInputReceived?.Invoke(delta);
        }
    }
}
