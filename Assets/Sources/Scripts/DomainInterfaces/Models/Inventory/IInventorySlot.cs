namespace Sources.Scripts.DomainInterfaces.Models.Inventory
{
    public interface IInventorySlot
    {
        bool IsEmpty { get; }
        int Level { get; }
    }
}