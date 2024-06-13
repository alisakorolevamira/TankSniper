using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.UIFramework.Presentations.Buttons;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService
    {
        private readonly IFormService _formService;
        private readonly UICollector _uiCollector;
        private InputMap _inputMap;
        private RectTransform _shootZone;

        public NewInputService(UICollector uiCollector, IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _shootZone = uiCollector.ShootZone;
        }

        public event Action<Vector2> RotationInputReceived;
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
        
            _inputMap.Enable();

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPreformed;
            _inputMap.Touchscreen.TouchPress.started += OnTouchPressPerformedStarted;
        }

        public void Exit()
        {
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPreformed;
            _inputMap.Touchscreen.TouchPress.started -= OnTouchPressPerformedEnded;
        }

        private void OnTouchDeltaPreformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());

        private void OnTouchPressPerformedStarted(InputAction.CallbackContext context)
        {
            var currentTouchPosition = _inputMap.Touchscreen.TouchPosition.ReadValue<Vector2>();
            var isTouchInRect = RectTransformUtility.RectangleContainsScreenPoint(_shootZone, currentTouchPosition);

            if (isTouchInRect)
            {
                _inputMap.Touchscreen.TouchPress.canceled += OnTouchPressPerformedEnded;
                _formService.Show(FormId.Shoot);
            }
        }

        private void OnTouchPressPerformedEnded(InputAction.CallbackContext context)
        {
            AttackInputReceived?.Invoke();
            _inputMap.Touchscreen.TouchPress.canceled -= OnTouchPressPerformedEnded;
            _formService.Show(FormId.Hud);
        }
    }
}