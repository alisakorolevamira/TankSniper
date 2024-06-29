using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Inventory;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Factories.Views.Inventory
{
    public class InventoryTankButtonViewFactory
    {
        private readonly InventoryTankButtonPresenterFactory _presenterFactory;

        public InventoryTankButtonViewFactory(InventoryTankButtonPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IInventoryTankButtonView Create(InventoryTankButtonView view, PlayerWallet playerWallet, Upgrader upgrader)
        {
            InventoryTankButtonPresenter presenter = _presenterFactory.Create(view, playerWallet, upgrader);
            
            view.Construct(presenter);

            return view;
        }
    }
}