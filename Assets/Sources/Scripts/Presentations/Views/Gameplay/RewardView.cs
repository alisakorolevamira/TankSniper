using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.PresentationsInterfaces.UI.Texts;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Gameplay
{
    public class RewardView : PresentableView<RewardPresenter>, IRewardView
    {
        [SerializeField] private UIText _rewardUIText;

        public IUIText RewardUIText => _rewardUIText;
    }
}