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
    public class CreateMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public CreateMainMenuSceneService(
            ILoadService loadService,
            IEntityRepository entityRepository,
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
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = new Tutorial();
            _entityRepository.Add(tutorial);

            Volume volume = CreateVolume();
            
            GameData gameData = new GameData(ModelId.GameData, true);
            _entityRepository.Add(gameData);
            
            CurrentLevel currentLevel = new CurrentLevel(ModelId.CurrentLevel, ModelId.Gameplay);
            _entityRepository.Add(currentLevel);
            
            Level firstLevel = new Level(ModelId.Gameplay, false);
            _entityRepository.Add(firstLevel);
            Level secondLevel = new Level(ModelId.Gameplay2, false);
            _entityRepository.Add(secondLevel);
            Level thirdLevel = new Level(ModelId.Gameplay3, false);
            _entityRepository.Add(thirdLevel);
            Level fourthLevel = new Level(ModelId.Gameplay4, false);
            _entityRepository.Add(fourthLevel);
            Level fifthLevel = new Level(ModelId.Gameplay5, false);
            _entityRepository.Add(fifthLevel);
            Level sixthLevel = new Level(ModelId.Gameplay6, false);
            _entityRepository.Add(sixthLevel);

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
                currentLevel);
        }

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume();
            _entityRepository.Add(volume);
            
            return volume;
        }
    }
}