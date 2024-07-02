using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.Presentations.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public abstract class LoadGameplaySceneServiceBase : ILoadSceneService
    {
        private readonly GameplayHud _gameplayHud;
        private readonly GameplayRootGameObject _gameplayRootGameObject;
        private readonly PlayerViewFactory _playerViewFactory;
        private readonly EnemySpawnerViewFactory _enemySpawnerViewFactory;
        private readonly KilledEnemiesCounterViewFactory _killedEnemiesCounterViewFactory;
        private readonly ReloadWeaponViewFactory _reloadWeaponViewFactory;
        private readonly CameraViewFactory _cameraViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly RewardViewFactory _rewardViewFactory;
        private readonly SkinChangerViewFactory _skinChangerViewFactory;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly IGameOverService _gameOverService;
        private readonly ICameraService _cameraService;
        private readonly IVolumeService _volumeService;
        private readonly ISaveService _saveService;
        private readonly ISkinChangerService _skinChangerService;

        private readonly ILevelCompletedService _levelCompletedService;
        //private readonly IAdvertisingService _advertisingService;

        protected LoadGameplaySceneServiceBase(
            GameplayHud gameplayHud,
            GameplayRootGameObject gameplayRootGameObject,
            PlayerViewFactory playerViewFactory,
            EnemySpawnerViewFactory enemySpawnerViewFactory,
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            ReloadWeaponViewFactory reloadWeaponViewFactory,
            CameraViewFactory cameraViewFactory,
            VolumeViewFactory volumeViewFactory,
            RewardViewFactory rewardViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            IGameOverService gameOverService,
            ICameraService cameraService,
            IVolumeService volumeService,
            ISaveService saveService,
            ISkinChangerService skinChangerService,
            ILevelCompletedService levelCompletedService)
            //IAdvertisingService advertisingService,
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
            _gameplayRootGameObject = gameplayRootGameObject 
                ? gameplayRootGameObject 
                : throw new ArgumentNullException(nameof(gameplayRootGameObject));
            _enemySpawnerViewFactory = enemySpawnerViewFactory ?? 
                                       throw new ArgumentNullException(nameof(enemySpawnerViewFactory));
            _killedEnemiesCounterViewFactory = killedEnemiesCounterViewFactory ?? 
                                               throw new ArgumentNullException(nameof(killedEnemiesCounterViewFactory));
            _reloadWeaponViewFactory = reloadWeaponViewFactory ??
                                       throw new ArgumentNullException(nameof(reloadWeaponViewFactory));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _cameraViewFactory = cameraViewFactory ?? throw new ArgumentNullException(nameof(cameraViewFactory));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _rewardViewFactory = rewardViewFactory ?? throw new ArgumentNullException(nameof(rewardViewFactory));
            _skinChangerViewFactory = skinChangerViewFactory ??
                                      throw new ArgumentNullException(nameof(skinChangerViewFactory));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ??
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            //_advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
        }

        public void Load(IScenePayload scenePayload)
        {
            GameModels gameModels = LoadModels(scenePayload);
            
            //_advertisingService.Construct(gameModels.PlayerWallet);
            
            _levelCompletedService.Register(gameModels.KilledEnemiesCounter, gameModels.EnemySpawner);

            SavedLevel savedLevel = gameModels.SavedLevel;
            savedLevel.CurrentLevelId = scenePayload.SceneId;
            
            _volumeService.Register(gameModels.Volume);
            _volumeViewFactory.Create(_volumeService, _gameplayHud.VolumeView);
            
            _saveService.Register(gameModels.EnemySpawner);
            
            PlayerView playerView = _playerViewFactory.Create(gameModels.Player);

            //PlayerAttackerView playerAttackerView = _rootGameObject.PlayerAttackerView;
            //_playerAttackerViewFactory.Create(gameModels.PlayerAttacker, playerAttackerView);
            
            _gameOverService.Register(gameModels.CharacterHealth);;

            EnemySpawnerView enemySpawnerView = _gameplayRootGameObject.EnemySpawnerView;
            enemySpawnerView.SetPlayerView(playerView);
            _enemySpawnerViewFactory.Create(gameModels.EnemySpawner, gameModels.KilledEnemiesCounter, enemySpawnerView);
            
            foreach (KilledEnemiesCounterView view in _gameplayHud.KilledEnemiesCounterViews)
                _killedEnemiesCounterViewFactory.Create(gameModels.KilledEnemiesCounter, gameModels.EnemySpawner, view);

            foreach (CameraPositionView cameraPosition in _gameplayRootGameObject.CameraPositions)
                _cameraService.AddPosition(cameraPosition);

            _reloadWeaponViewFactory.Create(_gameplayHud.ReloadWeaponView);

            _rewardViewFactory.Create(_levelCompletedService, _gameplayHud.RewardView);
            
            _cameraService.SetPosition(PositionId.MainPosition);
            _cameraViewFactory.Create(_gameplayHud.CameraView);

            _skinChangerService.Construct(gameModels.SkinChanger);
            _skinChangerViewFactory.Create(gameModels.SkinChanger, _gameplayRootGameObject.SkinChangerView);
            
            _levelAvailabilityViewFactory.Create(gameModels.LevelAvailability, _gameplayHud.LevelAvailabilityView);
        }

        protected abstract GameModels LoadModels(IScenePayload scenePayload);
    }
}