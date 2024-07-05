using System;
using Newtonsoft.Json;
using Sources.Scripts.DomainInterfaces.Models.Data;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class MainMenuData : IData
    {
        [JsonProperty("index")]
        public int Index { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public MainMenuData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<MainMenuData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}