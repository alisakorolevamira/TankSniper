using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Volumes;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public class LoadMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        
        public LoadMainMenuSceneService(
            IEntityRepository entityRepository,
            ILoadService loadService,
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory, 
            IVolumeService volumeService,
            UICollectorFactory uiCollectorFactory,
            IFormService formService) 
            : base(
                mainMenuHud, 
                levelAvailabilityViewFactory,
                volumeViewFactory, 
                volumeService, 
                uiCollectorFactory,
                formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = _loadService.Load<Tutorial>(ModelId.Tutorial);
            
            Volume volume = _loadService.Load<Volume>(ModelId.Volume);
            
            GameData gameData = _loadService.Load<GameData>(ModelId.GameData);
            
            CurrentLevel currentLevel = _loadService.Load<CurrentLevel>(ModelId.CurrentLevel);
            
            Level firstLevel = _loadService.Load<Level>(ModelId.Gameplay);
            Level secondLevel = _loadService.Load<Level>(ModelId.Gameplay2);
            Level thirdLevel = _loadService.Load<Level>(ModelId.Gameplay3);
            Level fourthLevel = _loadService.Load<Level>(ModelId.Gameplay4);
            Level fifthLevel = _loadService.Load<Level>(ModelId.Gameplay5);
            Level sixthLevel = _loadService.Load<Level>(ModelId.Gameplay6);
            
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
                currentLevel);
        }
    }
}