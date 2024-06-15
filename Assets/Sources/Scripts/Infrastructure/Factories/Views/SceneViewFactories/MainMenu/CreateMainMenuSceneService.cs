using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
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
            IFormService formService,
            ITutorialService tutorialService)
            : base(
                mainMenuHud,
                levelAvailabilityViewFactory,
                volumeViewFactory,
                volumeService,
                uiCollectorFactory,
                formService,
                tutorialService)
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
            
            SavedLevel savedLevel = new SavedLevel(ModelId.CurrentLevel, ModelId.FirstLevel);
            _entityRepository.Add(savedLevel);
            
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
                savedLevel);
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