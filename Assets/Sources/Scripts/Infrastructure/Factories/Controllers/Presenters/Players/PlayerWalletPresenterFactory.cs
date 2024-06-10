﻿using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class PlayerWalletPresenterFactory
    {
        public PlayerWalletPresenter Create(PlayerWallet playerWallet) =>
            new (playerWallet);
    }
}