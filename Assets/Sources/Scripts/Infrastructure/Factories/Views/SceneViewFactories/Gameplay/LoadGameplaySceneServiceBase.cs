using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public abstract class LoadGameplaySceneServiceBase : ILoadSceneService
    {
        private readonly GameplayHud _gameplayHud;
        //private readonly GameplayFormServiceFactory _mvpGameplayFormServiceFactory;
        private readonly UICollectorFactory _uiCollectorFactory;
        //private readonly CharacterViewFactory _characterViewFactory;
        //private readonly IUpgradeUIFactory _upgradeUIFactory;
        private readonly RootGameObject _rootGameObject;
        //private readonly EnemySpawnViewFactory _enemySpawnViewFactory;
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
            //CharacterViewFactory characterViewFactory,
            //IUpgradeUiFactory upgradeUiFactory,
            RootGameObject rootGameObject,
            //EnemySpawnViewFactory enemySpawnViewFactory,
            //ItemSpawnerViewFactory itemSpawnerViewFactory,
            //CustomCollection<Upgrader> upgradeCollection,
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            //BackgroundMusicViewFactory backgroundMusicViewFactory,
            IGameOverService gameOverService,
            CameraViewFactory cameraViewFactory,
            ICameraService cameraService,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            //IAdvertisingService advertisingService,
            IFormService formService)
            //UpgradeControllerViewFactory upgradeControllerViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            //_characterViewFactory = characterViewFactory ?? 
            //                        throw new ArgumentNullException(nameof(characterViewFactory));
            //_bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            //_upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _rootGameObject = rootGameObject 
                ? rootGameObject 
                : throw new ArgumentNullException(nameof(rootGameObject));
            //_enemySpawnViewFactory = enemySpawnViewFactory ?? 
            //                         throw new ArgumentNullException(nameof(enemySpawnViewFactory));
            //_itemSpawnerViewFactory = itemSpawnerViewFactory ?? 
            //                          throw new ArgumentNullException(nameof(itemSpawnerViewFactory));
            //_upgradeCollection = upgradeCollection ?? 
            //                            throw new ArgumentNullException(nameof(upgradeCollection));
            _killedEnemiesCounterViewFactory = killedEnemiesCounterViewFactory ?? 
                                               throw new ArgumentNullException(nameof(killedEnemiesCounterViewFactory));
                //_backgroundMusicViewFactory = backgroundMusicViewFactory ?? 
                //                              throw new ArgumentNullException(nameof(backgroundMusicViewFactory));
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
            //_scoreCounterViewFactory = scoreCounterViewFactory ?? throw new ArgumentNullException(nameof(scoreCounterViewFactory));
            //_upgradeControllerViewFactory = upgradeControllerViewFactory ?? 
            //                                throw new ArgumentNullException(nameof(upgradeControllerViewFactory));
        }

        public void Load(IScenePayload scenePayload)
        {
            GameModels gameModels = LoadModels(scenePayload);
            
            //_advertisingService.Construct(gameModels.PlayerWallet);
            
            //_levelCompletedService.Register(gameModels.KilledEnemiesCounter, gameModels.EnemySpawner);

            CurrentLevel currentLevel = gameModels.CurrentLevel;
            gameModels.CurrentLevel.CurrentLevelId = scenePayload.SceneId;
            
            _volumeService.Register(gameModels.Volume);
            _volumeViewFactory.Create(gameModels.Volume, _gameplayHud.VolumeView);
            
            //_saveService.Register(gameModels.EnemySpawner);

            //CharacterView characterView = _characterViewFactory.Create(gameModels.Character);


            _gameOverService.Register(gameModels.PlayerHealth);;

            //EnemySpawnerView enemySpawnView = _rootGameObject.EnemySpawnerView;
            //enemySpawnView.SetCharacterView(characterView);
            //_enemySpawnViewFactory.Create(
            //    gameModels.EnemySpawner, gameModels.KillEnemyCounter, enemySpawnView);
            //_itemSpawnerViewFactory.Create(_rootGameObject.ItemSpawnerView);
            
            //_killedEnemiesCounterViewFactory.Create(
                //gameModels.KilledEnemiesCounter, gameModels.EnemySpawner, _gameplayHud.KilledEnemiesCounterView);
            
            //_backgroundMusicViewFactory.Create(_gameplayHud.BackgroundMusicView);

            Debug.Log("camera");
            _cameraService.AddPosition(_rootGameObject.Position);
            _cameraService.SetPosition(PositionId.MainPosition);
            _cameraViewFactory.Create(_gameplayHud.CinemachineCameraView);
            
            _uiCollectorFactory.Create();
            _formService.Show(FormId.Hud);
        }

        protected abstract GameModels LoadModels(IScenePayload scenePayload);
    }
}