using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Inventory;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventoryGridView
    {
        IReadOnlyList<InventorySlotView> Slots { get; }
    }
}