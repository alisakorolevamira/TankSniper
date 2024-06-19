using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventorySlotView : View, IInventorySlotView
    {
        [SerializeField] private Vector2Int _position;
        
        public Vector2Int Position => _position;
        public bool IsEmpty { get; private set; }
        public int Level { get; private set; }
        public IInventoryTankView CurrentTank { get; private set; }
        public void Construct(InventorySlot slot)
        {
            IsEmpty = slot.IsEmpty;
            Level = slot.Level;
        }

        public void SetTank(IInventoryTankView tankView)
        {
            IsEmpty = false;
            CurrentTank = tankView;
            Level = tankView.Level;
        }

        public void ClearSlot()
        {
            IsEmpty = true;
            CurrentTank = null;
            Level = 0;
        }
    }
}