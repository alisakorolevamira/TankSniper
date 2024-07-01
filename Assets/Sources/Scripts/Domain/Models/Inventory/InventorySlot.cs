using Sources.Scripts.DomainInterfaces.Models.Inventory;

namespace Sources.Scripts.Domain.Models.Inventory
{
    public class InventorySlot : IInventorySlot
    {
        public InventorySlot(bool isEmpty, int level)
        {
            IsEmpty = isEmpty;
            Level = level;
        }
        
        public bool IsEmpty { get; private set; }
        public int Level { get; private set; }

        public void ChangeValues(bool isEmpty, int level)
        {
            IsEmpty = isEmpty;
            Level = level;
        }
    }
}