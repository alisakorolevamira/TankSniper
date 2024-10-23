using System;
using System.Threading;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.Presentations.UI.Huds;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class GameplayInputService : IInputService
    {
        private readonly GameplayHud _hud;
        private readonly IEntityRepository _entityRepository;
        
        private InputMap _inputMap;
        private bool _isAimButtonAvailable;
        private string _currentLevel;
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _delay = TimeSpan.FromMilliseconds(5f);

        public GameplayInputService(GameplayHud hud, IEntityRepository entityRepository)
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public event Action<Vector2> RotationInputReceived;
        public event Action AttackInputReceived;

        public void Enter(object payload = null)
        {
            _inputMap = new InputMap();
            _cancellationTokenSource = new CancellationTokenSource();
            _isAimButtonAvailable = true;
            _currentLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel).CurrentLevelId;
        
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
            if (_currentLevel is LevelConst.EleventhLevel or LevelConst.SeventeenthLevel)
                return;
            
            Signal.Send(StreamId.Gameplay.Shoot);
        }

        private void OnAimButtonUp() => 
            AttackInputReceived?.Invoke();
    }
}