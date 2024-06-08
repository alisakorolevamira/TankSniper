using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenter : PresenterBase
    {
        private readonly LevelAvailability _levelAvailability;
        private readonly ILevelAvailabilityView _levelAvailabilityView;
        
        public LevelAvailabilityPresenter(
            LevelAvailability levelAvailability, 
            ILevelAvailabilityView levelAvailabilityView)
        {
            _levelAvailability = levelAvailability ?? 
                                 throw new ArgumentNullException(nameof(levelAvailability));
            _levelAvailabilityView = levelAvailabilityView ?? 
                                     throw new ArgumentNullException(nameof(levelAvailabilityView));

            if (_levelAvailabilityView.Levels.Count != _levelAvailability.Levels.Count)
                throw new IndexOutOfRangeException(nameof(_levelAvailability.Levels));
        }

    }
}