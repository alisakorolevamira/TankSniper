using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly UICollectorFactory _uiCollectorFactory;
        private readonly IFormService _formService;
        
        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            UICollectorFactory uiCollectorFactory,
            IFormService formService)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public void Load(IScenePayload scenePayload)
        {
            MainMenuModels models = LoadModels(scenePayload);
            
            //CurrentLevel currentLevel = models.CurrentLevel;
            
            _volumeViewFactory.Create(models.Volume, _mainMenuHud.VolumeView);
            _volumeService.Register(models.Volume);
            
            _levelAvailabilityViewFactory.Create(models.LevelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            _uiCollectorFactory.Create();
            _formService.Show(FormId.Hud);
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}