using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.PresentationsInterfaces.UI.Texts;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class WalletUI : PresentableView<WalletUIPresenter>, IWalletUI
    {
        [SerializeField] private UIText _moneyText;

        public IUIText MoneyText => _moneyText;
    }
}