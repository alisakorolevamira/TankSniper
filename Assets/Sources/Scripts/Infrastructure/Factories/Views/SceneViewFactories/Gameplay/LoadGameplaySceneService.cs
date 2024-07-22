using System;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Sources.Scripts.Infrastructure.Factories.Views.Stickman;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
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
            GameplayRootGameObject gameplayRootGameObject, 
            IEntityRepository entityRepository, 
            PlayerViewFactory playerViewFactory,
            EnemySpawnerViewFactory enemySpawnerViewFactory, 
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            ReloadWeaponViewFactory reloadWeaponViewFactory,
            CameraViewFactory cameraViewFactory, 
            VolumeViewFactory volumeViewFactory,
            RewardViewFactory rewardViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            StickmanChangerViewFactory stickmanChangerViewFactory,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            ILoadService loadService, 
            IGameOverService gameOverService, 
            ICameraService cameraService, 
            IVolumeService volumeService,
            ISkinChangerService skinChangerService,
            IStickmanChangerService stickmanChangerService,
            ILevelCompletedService levelCompletedService)
            : base(
                gameplayHud, 
                gameplayRootGameObject, 
                playerViewFactory,
                enemySpawnerViewFactory, 
                killedEnemiesCounterViewFactory,
                reloadWeaponViewFactory,
                cameraViewFactory, 
                volumeViewFactory,
                rewardViewFactory,
                skinChangerViewFactory,
                stickmanChangerViewFactory,
                levelAvailabilityViewFactory,
                gameOverService, 
                cameraService, 
                volumeService,
                skinChangerService,
                stickmanChangerService,
                levelCompletedService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            _loadService.LoadAll();
            
            Volume volume = _entityRepository.Get<Volume>(ModelId.Volume);

            MainMenuAppearance mainMenu = _entityRepository.Get<MainMenuAppearance>(ModelId.MainMenuAppearance);

            GameLevels gameLevels = _entityRepository.Get<GameLevels>(ModelId.GameLevels);
            Level level = gameLevels.Levels.Find(level => level.Id == scenePayload.SceneId);
            
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            
            PlayerWallet playerWallet = _entityRepository.Get<PlayerWallet>(ModelId.PlayerWallet);
            
            Upgrader upgrader = _entityRepository.Get<Upgrader>(ModelId.Upgrader);

            SkinChanger skinChanger = _entityRepository.Get<SkinChanger>(ModelId.SkinChanger);

            StickmanChanger stickmanChanger = _entityRepository.Get<StickmanChanger>(ModelId.StickmanChanger);
            
            KilledEnemiesCounter killedEnemiesCounter = new KilledEnemiesCounter();

            EnemySpawner enemySpawner = new EnemySpawner();

            CharacterHealth characterHealth = new CharacterHealth();

            Weapon weapon = new Weapon(PlayerConst.Damage);

            PlayerAttacker playerAttacker = new PlayerAttacker(weapon);
            
            LevelAvailability levelAvailability = new LevelAvailability(gameLevels.Levels, mainMenu.Index);
            
            GameplayPlayer player = new GameplayPlayer(playerWallet, characterHealth, playerAttacker, weapon);
            
            return new GameModels(
                mainMenu,
                characterHealth,
                playerWallet,
                playerAttacker,
                volume,
                level,
                player,
                killedEnemiesCounter,
                enemySpawner,
                upgrader,
                skinChanger,
                stickmanChanger,
                levelAvailability,
                savedLevel);
        }
    }
}