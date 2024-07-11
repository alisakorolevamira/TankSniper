using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
        
        [JsonProperty("DecalButtons")]
        public List<ShopDecalButton> DecalButtons { get; set; }
        

        public void Save(string key)
        {
            string jsonPattern = JsonConvert.SerializeObject(PatternButtons, Formatting.Indented)?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString("Pattern", jsonPattern);
            
            string jsonDecal = JsonConvert.SerializeObject(DecalButtons, Formatting.Indented)?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString("Decal", jsonDecal);
        }
        
        public PlayerShopData Load(string key)
        {
            string jsonPattern = PlayerPrefs.GetString("Pattern", string.Empty);

            if (string.IsNullOrEmpty(jsonPattern))
                throw new NullReferenceException(nameof(key));
            
            string jsonDecal = PlayerPrefs.GetString("Decal", string.Empty);

            if (string.IsNullOrEmpty(jsonPattern))
                throw new NullReferenceException(nameof(key));
            
            PlayerShopData shopData = new PlayerShopData
            {
                PatternButtons = new List<ShopPatternButton>(),
                DecalButtons = new List<ShopDecalButton>()
            };
            
            shopData.PatternButtons = JsonConvert.DeserializeObject<List<ShopPatternButton>>(jsonPattern) ?? 
                                      throw new NullReferenceException(nameof(jsonPattern));
            
            shopData.DecalButtons = JsonConvert.DeserializeObject<List<ShopDecalButton>>(jsonDecal) ?? 
                                    throw new NullReferenceException(nameof(jsonDecal));

            return shopData;
        }
    }
}