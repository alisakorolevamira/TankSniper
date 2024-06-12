using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public abstract class LoadGameplaySceneServiceBase : ILoadSceneService
    {
        private readonly GameplayHud _gameplayHud;
        private readonly UICollectorFactory _uiCollectorFactory;
        private readonly PlayerViewFactory _playerViewFactory;
        private readonly RootGameObject _rootGameObject;
        private readonly EnemySpawnerViewFactory _enemySpawnerViewFactory;
        private readonly KilledEnemiesCounterViewFactory _killedEnemiesCounterViewFactory;
        private readonly IGameOverService _gameOverService;
        private readonly CameraViewFactory _cameraViewFactory;
        private readonly ICameraService _cameraService;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        //private readonly IAdvertisingService _advertisingService;
        private readonly IFormService _formService;

        protected LoadGameplaySceneServiceBase(
            GameplayHud gameplayHud,
            UICollectorFactory uiCollectorFactory,
            PlayerViewFactory playerViewFactory,
            RootGameObject rootGameObject,
            EnemySpawnerViewFactory enemySpawnerViewFactory,
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            IGameOverService gameOverService,
            CameraViewFactory cameraViewFactory,
            ICameraService cameraService,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            //IAdvertisingService advertisingService,
            IFormService formService)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
            _rootGameObject = rootGameObject 
                ? rootGameObject 
                : throw new ArgumentNullException(nameof(rootGameObject));
            _enemySpawnerViewFactory = enemySpawnerViewFactory ?? 
                                       throw new ArgumentNullException(nameof(enemySpawnerViewFactory));
            _killedEnemiesCounterViewFactory = killedEnemiesCounterViewFactory ?? 
                                               throw new ArgumentNullException(nameof(killedEnemiesCounterViewFactory));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _cameraViewFactory = cameraViewFactory ?? throw new ArgumentNullException(nameof(cameraViewFactory));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            //_advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Load(IScenePayload scenePayload)
        {
            GameModels gameModels = LoadModels(scenePayload);
            
            //_advertisingService.Construct(gameModels.PlayerWallet);
            
            _levelCompletedService.Register(gameModels.KilledEnemiesCounter, gameModels.EnemySpawner);

            CurrentLevel currentLevel = gameModels.CurrentLevel;
            gameModels.CurrentLevel.CurrentLevelId = scenePayload.SceneId;
            
            _volumeService.Register(gameModels.Volume);
            _volumeViewFactory.Create(gameModels.Volume, _gameplayHud.VolumeView);
            
            _saveService.Register(gameModels.EnemySpawner);

            PlayerView playerView = _playerViewFactory.Create(gameModels.Player);
            
            _gameOverService.Register(gameModels.CharacterHealth);;

            EnemySpawnerView enemySpawnerView = _rootGameObject.EnemySpawnerView;
            enemySpawnerView.SetPlayerView(playerView);
            _enemySpawnerViewFactory.Create(gameModels.EnemySpawner, gameModels.KilledEnemiesCounter, enemySpawnerView);
            
            foreach (KilledEnemiesCounterView view in _gameplayHud.KilledEnemiesCounterViews)
                _killedEnemiesCounterViewFactory.Create(gameModels.KilledEnemiesCounter, gameModels.EnemySpawner, view);

            foreach (CameraPositionView cameraPosition in _rootGameObject.CameraPositions)
                _cameraService.AddPosition(cameraPosition);
            
            _uiCollectorFactory.Create();
            _cameraService.SetPosition(PositionId.MainPosition);
            _cameraViewFactory.Create(_gameplayHud.CameraView);
            
            _formService.Show(FormId.Entry);
        }

        protected abstract GameModels LoadModels(IScenePayload scenePayload);
    }
}