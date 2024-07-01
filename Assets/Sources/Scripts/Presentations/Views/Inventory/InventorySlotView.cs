using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventorySlotView : View, IInventorySlotView
    {
        [SerializeField] private Vector2Int _position;

        private InventorySlot _slot;
        
        public Vector2Int Position => _position;
        public bool IsEmpty => _slot.IsEmpty;
        public int Level => _slot.Level;
        public IInventoryTankView CurrentTank { get; private set; }
        
        public void Construct(InventorySlot slot) => 
            _slot = slot;

        public void SetTank(IInventoryTankView tankView)
        {
            CurrentTank = tankView;
            _slot.ChangeValues(false, tankView.Level);
        }

        public void ClearSlot()
        {
            CurrentTank = null;
            _slot.ChangeValues(true, 0);
        }
    }
}