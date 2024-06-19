using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Inventory;
using UnityEngine;

namespace Sources.Scripts.Interfaces
{
    public interface IInventoryGrid
    {
        Dictionary<Vector2Int, InventorySlot> Slots { get; }
    }
}