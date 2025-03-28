﻿using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Controllers.Presenters.Scenes;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Forms;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly ICameraService _cameraService;
        private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly LoadGameplaySceneService _loadGameplaySceneService;
        private readonly CreateGameplaySceneService _createGameplaySceneService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly IStickmanChangerService _stickmanChangerService;
        private readonly IAudioService _audioService;
        private readonly IFormSignalController _formSignalController;
        private readonly IButtonSignalController _buttonSignalController;
        private readonly LoadingCurtainView _curtainView;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputService inputService,
            ICameraService cameraService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadGameplaySceneService loadGameplaySceneService,
            CreateGameplaySceneService createGameplaySceneService,
            ILevelCompletedService levelCompletedService,
            ISkinChangerService skinChangerService,
            IStickmanChangerService stickmanChangerService,
            LoadingCurtainView curtainView,
            IAudioService audioService,
            IFormSignalController formSignalController,
            IButtonSignalController buttonSignalController)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadGameplaySceneService = loadGameplaySceneService ?? 
                                        throw new ArgumentNullException(nameof(loadGameplaySceneService));
            _createGameplaySceneService = createGameplaySceneService ?? 
                                          throw new ArgumentNullException(nameof(createGameplaySceneService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _stickmanChangerService = stickmanChangerService ??
                                      throw new ArgumentNullException(nameof(stickmanChangerService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _formSignalController = formSignalController ?? throw new ArgumentNullException(nameof(formSignalController));
            _buttonSignalController = buttonSignalController ?? throw new ArgumentNullException(nameof(buttonSignalController));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene(
                _updateService,
                _inputService,
                _cameraService,
                CreateLoadSceneService(payload),
                _gameOverService,
                _volumeService,
                _levelCompletedService,
                _audioService,
                _skinChangerService,
                _stickmanChangerService,
                _formSignalController,
                _buttonSignalController,
                _curtainView);
        }

        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (payload == null)
                return _createGameplaySceneService;

            var canLoad = payload is IScenePayload { CanLoad : true };

            if (canLoad == false)
                return _createGameplaySceneService;

            return _loadGameplaySceneService;
        }
    }
}