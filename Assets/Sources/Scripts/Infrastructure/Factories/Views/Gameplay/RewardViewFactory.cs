using System;
using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Views.Gameplay
{
    public class RewardViewFactory
    {
        private readonly RewardPresenterFactory _presenterFactory;

        public RewardViewFactory(RewardPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IRewardView Create(ILevelCompletedService levelCompletedService, RewardView view)
        {
            RewardPresenter presenter = _presenterFactory.Create(levelCompletedService, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}