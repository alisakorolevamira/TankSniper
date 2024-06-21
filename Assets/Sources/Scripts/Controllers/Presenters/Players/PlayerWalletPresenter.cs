using System;
using Sources.Scripts.Domain.Models.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class PlayerWalletPresenter : PresenterBase
    {
        private readonly PlayerWallet _playerWallet;

        public PlayerWalletPresenter(PlayerWallet playerWallet)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
        }

        public void AddMoney(int amount)
        {
            if (amount < 0)
                return;
            
            _playerWallet.AddMoney(amount);
        }
    }
}