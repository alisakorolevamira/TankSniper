using System;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class PlayerWalletPresenter : PresenterBase
    {
        private readonly IPlayerWallet _playerWallet;
        private readonly IPlayerWalletView _playerWalletView;

        public PlayerWalletPresenter(IPlayerWallet playerWallet, IPlayerWalletView playerWalletView)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _playerWalletView = playerWalletView ?? throw new ArgumentNullException(nameof(playerWalletView));
        }

        public override void Enable()
        {
            OnMoneyChanged();
            _playerWallet.MoneyChanged += OnMoneyChanged;
        }

        public override void Disable() =>
            _playerWallet.MoneyChanged -= OnMoneyChanged;

        private void OnMoneyChanged() =>
            _playerWalletView.MoneyUIText.SetText(_playerWallet.Money.ToString());
    }
}