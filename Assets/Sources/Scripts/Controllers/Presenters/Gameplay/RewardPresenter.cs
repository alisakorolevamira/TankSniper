using System;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Controllers.Presenters.Gameplay
{
    public class RewardPresenter : PresenterBase
    {
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly IRewardView _rewardView;

        public RewardPresenter(
            ILevelCompletedService levelCompletedService,
            IRewardView rewardView)
        {
            _levelCompletedService = levelCompletedService ??
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _rewardView = rewardView ?? throw new ArgumentNullException(nameof(rewardView));
        }

        public override void Enable() => 
            _levelCompletedService.LevelCompleted += OnLevelCompleted;

        public override void Disable() => 
            _levelCompletedService.LevelCompleted -= OnLevelCompleted;

        private void OnLevelCompleted(int reward) => 
            _rewardView.RewardUIText.SetText($"Reward: {reward}");
    }
}