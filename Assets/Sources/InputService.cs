using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources
{
    public class InputService
    {
        private readonly InputMap _inputMap;
        public event Action<Vector2> RotationInputReceived;

        public InputService(InputMap inputMap)
        {
            _inputMap = inputMap ?? throw new ArgumentNullException(nameof(inputMap));

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPreformed;
        }

        private void OnTouchDeltaPreformed(InputAction.CallbackContext context)
        {
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
        }
    }
}
