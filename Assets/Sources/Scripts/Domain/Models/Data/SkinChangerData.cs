using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class SkinChangerData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public SkinType CurrentSkinType { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public MaterialType CurrentMaterialType { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public DecalType CurrentDecalType { get; set; }

        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(this) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public SkinChangerData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            return JsonConvert.DeserializeObject<SkinChangerData>(json) ?? 
                   throw new NullReferenceException(nameof(json));
        }
    }
}