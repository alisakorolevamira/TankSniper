using System;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Inventory;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Factories.Views.Inventory
{
    public class InventoryGridViewFactory 
    {
        private readonly InventoryGridPresenterFactory _presenterFactory;

        public InventoryGridViewFactory(InventoryGridPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }
        
        public IInventoryGridView Create(InventoryGridView view, InventoryGrid grid)
        {
            InventoryGridPresenter presenter = _presenterFactory.Create(grid, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}