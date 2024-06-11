using System;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.Domain.Models.Inputs;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService, IEnable, IDisable
    {
        private InputMap _inputMap;

        public event Action<Vector2> RotationInputReceived;

        public void Enable()
        {
            _inputMap = new ();
        
            _inputMap.Enable();

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPreformed;
        }

        public void Disable()
        {
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPreformed;
        }
        
        private void OnTouchDeltaPreformed(InputAction.CallbackContext context)
        {
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
        }
    }
}