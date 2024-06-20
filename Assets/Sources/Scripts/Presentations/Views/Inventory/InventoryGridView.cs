using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventoryGridView : PresentableView<InventoryGridPresenter>, IInventoryGridView
    {
        [SerializeField] private List<InventorySlotView> _slots;

        public IReadOnlyList<InventorySlotView> Slots => _slots;
    }
}