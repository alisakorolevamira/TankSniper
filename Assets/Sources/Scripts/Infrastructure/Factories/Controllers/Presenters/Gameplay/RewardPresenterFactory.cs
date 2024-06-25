using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class RewardPresenterFactory
    {
        public RewardPresenter Create(ILevelCompletedService levelCompletedService, IRewardView view)
        {
            return new RewardPresenter(levelCompletedService, view);
        }
    }
}