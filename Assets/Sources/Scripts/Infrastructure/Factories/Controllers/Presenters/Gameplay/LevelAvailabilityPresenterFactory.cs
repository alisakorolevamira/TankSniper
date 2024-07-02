using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenterFactory
    {
        public LevelAvailabilityPresenter Create(
            LevelAvailability levelAvailability,
            ILevelAvailabilityView levelAvailabilityView)
        {
            return new LevelAvailabilityPresenter(levelAvailability, levelAvailabilityView);
        }
    }
}