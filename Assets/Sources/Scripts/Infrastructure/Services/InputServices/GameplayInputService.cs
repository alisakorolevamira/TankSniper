using System;
using System.Collections.Generic;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.Presentations.UI.Huds;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class GameplayInputService : IInputService
    {
        private readonly GameplayHud _hud;
        private InputMap _inputMap;

        public GameplayInputService(GameplayHud hud)
        {
            _hud = hud ?? throw new ArgumentNullException(nameof(hud));
        }

        public event Action<Vector2> RotationInputReceived;
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
        
            _inputMap.Enable();

            foreach (UIButton shootButton in _hud.ShootButtons)
            {
                shootButton.onPointerDownEvent.AddListener(OnAimButtonDown);
                shootButton.onPointerUpEvent.AddListener(OnAimButtonUp);
            }

            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPerformed;
        }

        public void Exit()
        {
            _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPerformed;
            
            foreach (UIButton shootButton in _hud.ShootButtons)
            {
                shootButton.onPointerDownEvent.RemoveListener(OnAimButtonDown);
                shootButton.onPointerUpEvent.RemoveListener(OnAimButtonUp);
            }
        }

        private void OnTouchDeltaPerformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());

        private void OnAimButtonDown() => 
            Signal.Send(StreamId.Gameplay.Shoot);

        private void OnAimButtonUp() => 
            AttackInputReceived?.Invoke();
    }
}