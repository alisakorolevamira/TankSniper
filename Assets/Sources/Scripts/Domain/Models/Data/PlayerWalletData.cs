using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class PlayerWalletData : IData
    {
        [JsonProperty("money")]
        public int Money { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public PlayerWalletData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<PlayerWalletData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}