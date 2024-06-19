using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public class LoadMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public LoadMainMenuSceneService(
            IEntityRepository entityRepository,
            ILoadService loadService,
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            IVolumeService volumeService,
            UICollectorFactory uiCollectorFactory,
            IFormService formService,
            ITutorialService tutorialService,
            MainMenuPlayerViewFactory playerViewFactory) 
            : base(
                mainMenuHud, 
                levelAvailabilityViewFactory,
                volumeViewFactory,
                inventoryGridViewFactory,
                volumeService, 
                uiCollectorFactory,
                formService,
                tutorialService,
                playerViewFactory)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = _loadService.Load<Tutorial>(ModelId.Tutorial);
            
            Volume volume = _loadService.Load<Volume>(ModelId.Volume);
            
            GameData gameData = _loadService.Load<GameData>(ModelId.GameData);
            
            SavedLevel savedLevel = _loadService.Load<SavedLevel>(ModelId.SavedLevel);
            
            Level firstLevel = _loadService.Load<Level>(ModelId.FirstLevel);
            Level secondLevel = _loadService.Load<Level>(ModelId.SecondLevel);
            Level thirdLevel = _loadService.Load<Level>(ModelId.ThirdLevel);
            Level fourthLevel = _loadService.Load<Level>(ModelId.FourthLevel);
            Level fifthLevel = _loadService.Load<Level>(ModelId.FifthLevel);
            Level sixthLevel = _loadService.Load<Level>(ModelId.SixthLevel);
            
            LevelAvailability levelAvailability = new LevelAvailability(
                new List<Level>()
                {
                    firstLevel,
                    secondLevel,
                    thirdLevel,
                    fourthLevel,
                    fifthLevel,
                    sixthLevel
                });
            
            PlayerWallet playerWallet = _loadService.Load<PlayerWallet>(ModelId.PlayerWallet);

            Player player = new Player(playerWallet);

            InventorySlot firstSlot = _loadService.Load<InventorySlot>(ModelId.FirstSlot);
            InventorySlot secondSlot = _loadService.Load<InventorySlot>(ModelId.SecondSlot);
            InventorySlot thirdSlot = _loadService.Load<InventorySlot>(ModelId.ThirdSlot);
            InventorySlot fourthSlot = _loadService.Load<InventorySlot>(ModelId.FourthSlot);
            InventorySlot fifthSlot = _loadService.Load<InventorySlot>(ModelId.FifthSlot);
            InventorySlot sixthSlot = _loadService.Load<InventorySlot>(ModelId.SixthSlot);
            InventorySlot seventhSlot = _loadService.Load<InventorySlot>(ModelId.SeventhSlot);
            InventorySlot eighthSlot = _loadService.Load<InventorySlot>(ModelId.EighthSlot);
            InventorySlot ninthSlot = _loadService.Load<InventorySlot>(ModelId.NinthSlot);

            InventoryGrid inventoryGrid = new InventoryGrid(
                new List<InventorySlot>()
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
                });
            
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
                savedLevel,
                inventoryGrid);
        }
    }
}