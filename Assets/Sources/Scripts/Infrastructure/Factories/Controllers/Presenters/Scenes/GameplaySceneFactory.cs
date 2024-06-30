using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
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
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Forms;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;

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
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly List<ITankEnemyView> _enemiesViews;
        private readonly IAudioService _audioService;
        private readonly IFocusService _focusService;
        private readonly IFormSignalController _formSignalController;
        private readonly IButtonSignalController _buttonSignalController;
        //private readonly IAdvertisingService _advertisingService;
        private readonly LoadingCurtainView _curtainView;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputService inputService,
            ICameraService cameraService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadGameplaySceneService loadGameplaySceneService,
            CreateGameplaySceneService createGameplaySceneService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ISkinChangerService skinChangerService,
            List<ITankEnemyView> enemiesViews,
            LoadingCurtainView curtainView,
            IAudioService audioService,
            IFormSignalController formSignalController,
            IButtonSignalController buttonSignalController,
            IFocusService focusService)
            //IAdvertisingService advertisingService) 
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
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _enemiesViews = enemiesViews ?? throw new ArgumentNullException(nameof(enemiesViews));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _formSignalController = formSignalController ?? throw new ArgumentNullException(nameof(formSignalController));
            _buttonSignalController = buttonSignalController ?? throw new ArgumentNullException(nameof(buttonSignalController));
            //_advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
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
                _saveService,
                _levelCompletedService,
                _enemiesViews,
                _audioService,
                _focusService,
                _skinChangerService,
                _formSignalController,
                _buttonSignalController,
                _curtainView);
            //_advertisingService);
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