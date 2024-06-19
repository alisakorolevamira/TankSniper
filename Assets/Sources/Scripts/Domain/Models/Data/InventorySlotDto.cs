using Sources.Scripts.DomainInterfaces.Models.Data;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class InventorySlotDto : IDto
    {
        //[JsonProperty("id")]
        public string Id { get; set; }
        
        //[JsonProperty("isCompleted")]
        public bool IsEmpty { get; set; }
        
        public int Level { get; set; }
    }
}