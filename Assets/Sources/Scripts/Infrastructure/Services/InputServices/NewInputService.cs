using System;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService
    {
        private InputMap _inputMap;

        public event Action<Vector2> RotationInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
        
            _inputMap.Enable();

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPreformed;
        }

        public void Exit() => 
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPreformed;

        private void OnTouchDeltaPreformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
    }
}