using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Forms;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly ICameraService _cameraService;
        private readonly ILoadSceneService _loadSceneService;
        private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        private List<ITankEnemyView> _enemiesViews;
        private readonly IAudioService _audioService;
        private readonly IFocusService _focusService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly IButtonSignalController _buttonSignalController;
        private readonly IFormSignalController _formSignalController;
        //private readonly IAdvertisingService _advertisingService;
        private readonly LoadingCurtainView _curtainView;

        public GameplayScene(
            IUpdateService updateService,
            IInputService inputService,
            ICameraService cameraService,
            ILoadSceneService loadSceneService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            List<ITankEnemyView> enemiesViews,
            IAudioService audioService,
            IFocusService focusService,
            ISkinChangerService skinChangerService,
            IFormSignalController formSignalController,
            IButtonSignalController buttonSignalController,
            //IAdvertisingService advertisingService)
            LoadingCurtainView curtainView)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _skinChangerService = skinChangerService ??
                                   throw new ArgumentNullException(nameof(skinChangerService));
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ??
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _enemiesViews = enemiesViews ??
                                   throw new ArgumentNullException(nameof(enemiesViews));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _buttonSignalController = buttonSignalController ?? throw new ArgumentNullException(nameof(buttonSignalController));
            _formSignalController = formSignalController ?? throw new ArgumentNullException(nameof(formSignalController));
            //_advertisingService = advertisingService ??
            //                      throw new ArgumentNullException(nameof(advertisingService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async void Enter(object payload = null)
        {
            _focusService.Enable();
            _loadSceneService.Load(payload as IScenePayload);
            //_advertisingService.Enable();
            _volumeService.Enter();
            _gameOverService.Enter();
            _saveService.Enter();
            _levelCompletedService.Enable();
            _skinChangerService.Enable();
            _buttonSignalController.Initialize();
            _formSignalController.Initialize();
            _audioService.Enter();
            _inputService.Enter();
            _cameraService.Enter();
            await _curtainView.HideCurtain(); 
        }

        public void Exit()
        {
            _focusService.Disable();
            //_advertisingService.Disable();
            _updateService.UnregisterAll();
            _gameOverService.Exit();
            _volumeService.Exit();
            _saveService.Exit();
            _levelCompletedService.Disable();
            _audioService.Exit();
            _inputService.Exit();
            _cameraService.Exit();
            _enemiesViews.Clear();
            _buttonSignalController.Destroy();
            _formSignalController.Destroy();
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}