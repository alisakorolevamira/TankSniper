using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Domain.Models.Constants;
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
        private bool _isAimButtonAvailable;
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _delay = TimeSpan.FromMilliseconds(5f);

        public GameplayInputService(GameplayHud hud)
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
        }

        public event Action<Vector2> RotationInputReceived;
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
            _cancellationTokenSource = new CancellationTokenSource();
        
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
            
            _cancellationTokenSource.Cancel();
        }

        private void OnTouchDeltaPerformed(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());

        private void OnAimButtonDown()
        {
            if (_isAimButtonAvailable == false)
                return;
            
            Signal.Send(StreamId.Gameplay.Shoot);
            SetTimer(_cancellationTokenSource.Token);
        }

        private void OnAimButtonUp() => 
            AttackInputReceived?.Invoke();

        private async UniTask SetTimer(CancellationToken cancellationToken)
        {
            try
            {
                _isAimButtonAvailable = false;
                
                await UniTask.Delay(_delay, cancellationToken: cancellationToken);

                _isAimButtonAvailable = true;
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}