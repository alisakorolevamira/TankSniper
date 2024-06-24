using System;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.RootGameObjects;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public class LoadGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public LoadGameplaySceneService(
            GameplayHud gameplayHud, 
            PlayerViewFactory playerViewFactory,
            PlayerAttackerViewFactory playerAttackerViewFactory,
            ILoadService loadService, 
            IEntityRepository entityRepository, 
            GameplayRootGameObject gameplayRootGameObject, 
            EnemySpawnerViewFactory enemySpawnerViewFactory, 
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            ReloadWeaponViewFactory reloadWeaponViewFactory,
            IGameOverService gameOverService, 
            CameraViewFactory cameraViewFactory, 
            ICameraService cameraService, 
            VolumeViewFactory volumeViewFactory, 
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService)
            //IAdvertisingService advertisingService,
            : base(
                gameplayHud, 
                playerViewFactory,
                playerAttackerViewFactory,
                gameplayRootGameObject, 
                enemySpawnerViewFactory, 
                killedEnemiesCounterViewFactory,
                reloadWeaponViewFactory,
                gameOverService, 
                cameraViewFactory, 
                cameraService, 
                volumeViewFactory, 
                volumeService,
                saveService,
                levelCompletedService)
                //advertisingService,
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            _loadService.LoadAll();
            
            Volume volume = _entityRepository.Get<Volume>(ModelId.Volume);

            Level level = _entityRepository.Get<Level>(scenePayload.SceneId);
            
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            
            PlayerWallet playerWallet = _entityRepository.Get<PlayerWallet>(ModelId.PlayerWallet);
            
            Upgrader upgrader = _entityRepository.Get<Upgrader>(ModelId.Upgrader);

            KilledEnemiesCounter killedEnemiesCounter = new KilledEnemiesCounter();

            EnemySpawner enemySpawner = new EnemySpawner();

            CharacterHealth characterHealth = new CharacterHealth();

            Weapon weapon = new Weapon(PlayerConst.Damage);

            PlayerAttacker playerAttacker = new PlayerAttacker(weapon);
            
            GameplayPlayer player = new GameplayPlayer(playerWallet, characterHealth, playerAttacker, weapon);
            
            return new GameModels(
                characterHealth,
                playerWallet,
                playerAttacker,
                volume,
                level,
                player,
                killedEnemiesCounter,
                enemySpawner,
                upgrader,
                savedLevel);
        }
    }
}