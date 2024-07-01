using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class UpgradeData : IData
    {
        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public UpgradeData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<UpgradeData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}