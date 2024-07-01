using System;
using System.Collections.Generic;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Inventory;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class InventoryGridData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("slots")]
        public List<InventorySlot> Slots { get; set; }
        
        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(Slots, Formatting.Indented)?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public InventoryGridData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            InventoryGridData levelData = new InventoryGridData() {Slots = new List<InventorySlot>()};
            levelData.Slots = JsonConvert.DeserializeObject<List<InventorySlot>>(json) ?? 
                             throw new NullReferenceException(nameof(json));

            return levelData;
        }
    }
}