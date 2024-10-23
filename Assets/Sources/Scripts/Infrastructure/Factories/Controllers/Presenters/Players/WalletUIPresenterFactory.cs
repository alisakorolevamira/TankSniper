using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class WalletUIPresenterFactory
    {
        public WalletUIPresenter Create(IPlayerWallet playerWallet, IWalletUI walletUI) => 
            new(playerWallet, walletUI);
    }
}