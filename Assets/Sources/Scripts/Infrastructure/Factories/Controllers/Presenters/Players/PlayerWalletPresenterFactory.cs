using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class PlayerWalletPresenterFactory
    { 
        public PlayerWalletPresenter Create(PlayerWallet playerWallet)
        {
            return new PlayerWalletPresenter(playerWallet);
        }
    }
}