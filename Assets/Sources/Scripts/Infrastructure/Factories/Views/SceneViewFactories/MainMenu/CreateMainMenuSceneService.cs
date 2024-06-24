using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public class CreateMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public CreateMainMenuSceneService(
            ILoadService loadService,
            IEntityRepository entityRepository,
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            MainMenuPlayerViewFactory playerViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IPlayerSpawnerService playerSpawnerService,
            IUpgradeService upgradeService,
            IInventoryTankSpawnerService inventoryTankSpawnerService)
            : base(
                mainMenuHud,
                levelAvailabilityViewFactory,
                volumeViewFactory,
                inventoryGridViewFactory,
                volumeService,
                tutorialService,
                playerSpawnerService,
                inventoryTankSpawnerService,
                upgradeService,
                playerViewFactory)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = new Tutorial(ModelId.Tutorial, false);
            _entityRepository.Add(tutorial);

            Volume volume = CreateVolume();
            
            GameData gameData = new GameData(ModelId.GameData, true);
            _entityRepository.Add(gameData);
            
            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel, ModelId.FirstLevel);
            _entityRepository.Add(savedLevel);

            Upgrader upgrader = new Upgrader(1, ModelId.Upgrader);
            _entityRepository.Add(upgrader);
            
            Level firstLevel = new Level(ModelId.FirstLevel, false);
            _entityRepository.Add(firstLevel);
            Level secondLevel = new Level(ModelId.SecondLevel, false);
            _entityRepository.Add(secondLevel);
            Level thirdLevel = new Level(ModelId.ThirdLevel, false);
            _entityRepository.Add(thirdLevel);
            Level fourthLevel = new Level(ModelId.FourthLevel, false);
            _entityRepository.Add(fourthLevel);
            Level fifthLevel = new Level(ModelId.FifthLevel, false);
            _entityRepository.Add(fifthLevel);
            Level sixthLevel = new Level(ModelId.SixthLevel, false);
            _entityRepository.Add(sixthLevel);
            
            PlayerWallet playerWallet = new PlayerWallet(0, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);
            
            Player player = new Player(playerWallet);

            List<InventorySlot> slots = CreateSlots();

            InventoryGrid grid = new InventoryGrid(slots);

            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                    fifthLevel,
                    sixthLevel,
                });

            _loadService.SaveAll();

            return new MainMenuModels(
                volume,
                firstLevel,
                secondLevel,
                thirdLevel,
                fourthLevel,
                fifthLevel,
                sixthLevel,
                levelAvailability,
                gameData,
                tutorial,
                player,
                upgrader,
                savedLevel,
                grid);
        }

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume(VolumeConst.BaseAudioValue, ModelId.Volume);
            _entityRepository.Add(volume);
            
            return volume;
        }

        private List<InventorySlot> CreateSlots()
        {
            InventorySlot firstSlot = new InventorySlot(ModelId.FirstSlot, true, 0);
            _entityRepository.Add(firstSlot);
            InventorySlot secondSlot = new InventorySlot(ModelId.SecondSlot, true, 0);
            _entityRepository.Add(secondSlot);
            InventorySlot thirdSlot = new InventorySlot(ModelId.ThirdSlot, true, 0);
            _entityRepository.Add(thirdSlot);
            InventorySlot fourthSlot = new InventorySlot(ModelId.FourthSlot, true, 0);
            _entityRepository.Add(fourthSlot);
            InventorySlot fifthSlot = new InventorySlot(ModelId.FifthSlot, false, 1);
            _entityRepository.Add(fifthSlot);
            InventorySlot sixthSlot = new InventorySlot(ModelId.SixthSlot, true, 0);
            _entityRepository.Add(sixthSlot);
            InventorySlot seventhSlot = new InventorySlot(ModelId.SeventhSlot, true, 0);
            _entityRepository.Add(seventhSlot);
            InventorySlot eighthSlot = new InventorySlot(ModelId.EighthSlot, true, 0);
            _entityRepository.Add(eighthSlot);
            InventorySlot ninthSlot = new InventorySlot(ModelId.NinthSlot, true, 0);
            _entityRepository.Add(ninthSlot);

            List<InventorySlot> slots = new List<InventorySlot>
            {
                firstSlot,
                secondSlot,
                thirdSlot,
                fourthSlot,
                fifthSlot,
                sixthSlot,
                seventhSlot,
                eighthSlot,
                ninthSlot
            };

            return slots;
        }
    }
}