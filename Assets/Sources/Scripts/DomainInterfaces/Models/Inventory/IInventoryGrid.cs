using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Inventory;
using UnityEngine;

namespace Sources.Scripts.DomainInterfaces.Models.Inventory
{
    public interface IInventoryGrid
    {
        Dictionary<Vector2Int, InventorySlot> Slots { get; }
    }
}