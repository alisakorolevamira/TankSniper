using System;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class GameplayInputService : IInputService
    {
        private readonly IFormService _formService;
        private readonly GameplayHud _hud;
        private InputMap _inputMap;
        private RectTransform _shootZone;

        public GameplayInputService(GameplayHud hud, IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _hud = hud ?? throw new ArgumentNullException(nameof(hud));
            _shootZone = hud.ShootZone;
        }

        public event Action<Vector2> RotationInputReceived;
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
        
            _inputMap.Enable();

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPerformed;
            _inputMap.Touchscreen.TouchPress.started += OnTouchPressPerformedStarted;
        }

        public void Exit()
        {
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPerformed;
            _inputMap.Touchscreen.TouchPress.started -= OnTouchPressPerformedEnded;
        }

        private void OnTouchDeltaPerformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());

        private void OnTouchPressPerformedStarted(InputAction.CallbackContext context)
        {
            Vector2 currentTouchPosition = _inputMap.Touchscreen.TouchPosition.ReadValue<Vector2>();
            bool isTouchInRect = RectTransformUtility.RectangleContainsScreenPoint(_shootZone, currentTouchPosition);

            if (isTouchInRect != true)
                return;

            if (_formService.IsActive(FormId.Entry) || _formService.IsActive(FormId.Hud))
            {
                _inputMap.Touchscreen.TouchPress.canceled += OnTouchPressPerformedEnded;
                _formService.Show(FormId.Shoot);
            }
        }

        private void OnTouchPressPerformedEnded(InputAction.CallbackContext context)
        {
            AttackInputReceived?.Invoke();
            _inputMap.Touchscreen.TouchPress.canceled -= OnTouchPressPerformedEnded;
        }
    }
}