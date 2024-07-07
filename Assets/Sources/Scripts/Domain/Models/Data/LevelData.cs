using System;
using System.Collections.Generic;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Gameplay;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Data
{
    public class LevelData : IData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("levels")]
        public List<Level> Levels { get; set; }
        
        public void Save(string key)
        {
            string json = JsonConvert.SerializeObject(Levels, Formatting.Indented) ?? 
                          throw new NullReferenceException();
            
            PlayerPrefs.SetString(key, json);
        }

        public LevelData Load(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);
            
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException(nameof(key));
            
            LevelData levelData = new LevelData() {Levels = new List<Level>()};
            levelData.Levels = JsonConvert.DeserializeObject<List<Level>>(json);

            return levelData;
        }
    }
}