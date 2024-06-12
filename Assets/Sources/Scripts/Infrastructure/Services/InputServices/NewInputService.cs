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
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
        
            _inputMap.Enable();

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPreformed;
            _inputMap.Touchscreen.TouchUp.performed += OnTouchUpPerformed;
        }

        public void Exit()
        {
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPreformed;
            _inputMap.Touchscreen.TouchUp.performed -= OnTouchUpPerformed;
        }

        private void OnTouchDeltaPreformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());

        private void OnTouchUpPerformed(InputAction.CallbackContext context)
        {
            AttackInputReceived?.Invoke();
        }
    }
}