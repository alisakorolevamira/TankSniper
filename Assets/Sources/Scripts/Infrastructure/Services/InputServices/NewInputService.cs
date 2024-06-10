using System;
using Sources.Scripts.Domain.Models.Inputs;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService, IInputServiceUpdater
    {
        private readonly IPauseService _pauseService;
        //private InputManager _inputManager;

        public NewInputService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            //_inputManager = new InputManager();
            InputData = new InputData();

            //_inputManager.Enable();
        }

        public InputData InputData { get; }

        public void Update(float deltaTime)
        {
            if (_pauseService.IsPaused)
                return;
            
            UpdateAttack();
        }

        private void UpdateAttack()
        {
            
            //InputData.IsAttacking = _inputManager.Gameplay.Attack.IsPressed();
        }
    }
}