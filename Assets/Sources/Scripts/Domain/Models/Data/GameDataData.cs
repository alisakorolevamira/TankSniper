using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Gameplay;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class GameDataData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("wasLaunched")]
        public bool WasLaunched { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public GameDataData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

             if (string.IsNullOrEmpty(json))
                 throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<GameDataData>(json) ?? 
                                 throw new NullReferenceException(nameof(json));
        }
    }
}