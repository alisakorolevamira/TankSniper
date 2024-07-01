using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class SavedLevelData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("savedLevelId")]
        public string SavedLevelId { get; set; }
        
        //[JsonProperty("index")]
        //public int Index { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public SavedLevelData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<SavedLevelData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}