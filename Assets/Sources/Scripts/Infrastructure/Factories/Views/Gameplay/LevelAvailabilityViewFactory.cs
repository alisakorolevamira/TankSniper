using System;
using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Views.Gameplay
{
    public class LevelAvailabilityViewFactory
    {
        private readonly LevelAvailabilityPresenterFactory _presenterFactory;

        public LevelAvailabilityViewFactory(LevelAvailabilityPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ILevelAvailabilityView Create(
            LevelAvailability levelAvailability,
            LevelAvailabilityView levelAvailabilityView)
        {
            LevelAvailabilityPresenter presenter = _presenterFactory.Create(levelAvailability, levelAvailabilityView);
            
            levelAvailabilityView.Construct(presenter);
            
            return levelAvailabilityView;
        }
    }
}