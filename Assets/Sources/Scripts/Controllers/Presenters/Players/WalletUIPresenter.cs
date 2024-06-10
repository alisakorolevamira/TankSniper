using System;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class WalletUIPresenter : PresenterBase
    {
        private readonly IPlayerWallet _playerWallet;
        private readonly IWalletUI _walletUI;

        public WalletUIPresenter(IPlayerWallet playerWallet, IWalletUI walletUI)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _walletUI = walletUI ?? throw new ArgumentNullException(nameof(walletUI));
        }
        
        public override void Enable()
        {
            OnMoneyChanged();
            _playerWallet.MoneyChanged += OnMoneyChanged;
        }

        public override void Disable() =>
            _playerWallet.MoneyChanged -= OnMoneyChanged;

        private void OnMoneyChanged() =>
            _walletUI.MoneyText.SetText(_playerWallet.Money.ToString());
    }
}