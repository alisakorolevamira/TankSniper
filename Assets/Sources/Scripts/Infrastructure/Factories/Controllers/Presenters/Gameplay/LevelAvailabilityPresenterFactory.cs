using System;
using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenterFactory
    {
        private readonly ISceneService _sceneService;

        public LevelAvailabilityPresenterFactory(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LevelAvailabilityPresenter Create(
            LevelAvailability levelAvailability,
            ILevelAvailabilityView levelAvailabilityView)
        {
            return new LevelAvailabilityPresenter(levelAvailability, levelAvailabilityView, _sceneService);
        }
    }
}