using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class WalletUIFactory
    {
        private readonly WalletUIPresenterFactory _presenterFactory;

        public WalletUIFactory(WalletUIPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IWalletUI Create(IPlayerWallet playerWallet, WalletUI walletUI)
        {
            WalletUIPresenter presenter = _presenterFactory.Create(playerWallet, walletUI);
            
            walletUI.Construct(presenter);

            return walletUI;
        }
    }
}