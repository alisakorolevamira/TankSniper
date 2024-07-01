using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class VolumeData : IData
    {
        [JsonProperty("audioValue")]
        public int AudioValue { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public VolumeData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<VolumeData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}