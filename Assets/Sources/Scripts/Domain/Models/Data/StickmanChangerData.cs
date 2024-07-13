using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.Presentations.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class StickmanChangerData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public StickmanType CurrentStickmanType { get; set; }
        
        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public StickmanChangerData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<StickmanChangerData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}