using System.Collections.Generic;
using UnityEngine;

namespace Sources.Scripts
{
    public class InventoryEntryPoint : MonoBehaviour
    {
        [SerializeField] private InventoryGridView _view;
        
        private void Start()
        {
            var inventoryData = new InventoryGridData
            {
                Size = new Vector2Int(3, 3),
                Slots = new List<InventorySlotData>()
            };
            
            var inventory = new InventoryGrid(inventoryData);
            
            _view.Setup(inventory);
        }
    }
}