using Sources.Scripts.Interfaces;
using UnityEngine;

namespace Sources.Scripts
{
    public class InventoryGridView : MonoBehaviour
    {
        public void Setup(IInventoryGrid inventoryGrid)
        {
            var slots = inventoryGrid.GetSlots();
            var size = inventoryGrid.Size;
            
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    var slot = slots[i, j];
                }
            }
        }
    }
}