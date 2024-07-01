using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.DomainInterfaces.Models.Data;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class PlayerShopData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("PatternButtons")]
        public List<ShopPatternButton> PatternButtons { get; set; }
        

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(PatternButtons, Formatting.Indented)?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }
        
        public PlayerShopData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            PlayerShopData shopData = new PlayerShopData() {PatternButtons = new List<ShopPatternButton>()};
            shopData.PatternButtons = JsonConvert.DeserializeObject<List<ShopPatternButton>>(json) ?? 
                                      throw new NullReferenceException(nameof(json));

            return shopData;
        }
    }
}