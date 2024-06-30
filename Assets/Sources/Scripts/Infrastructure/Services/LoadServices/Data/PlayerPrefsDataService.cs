using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices.Data;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.LoadServices.Data
{
    public class PlayerPrefsDataService : IDataService
    {
        public T LoadData<T>(string key)
            where T : IDto => 
            (T)LoadData(key, typeof(T));

        public object LoadData(string key, Type dtoType)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

           // if (string.IsNullOrEmpty(json))
           //     throw new NullReferenceException(nameof(key));

            if (key == ModelId.GameLevels)
            {
                LevelDto levelDto = new LevelDto() {Id = ModelId.GameLevels, Levels = new List<Level>()};
                levelDto.Levels = JsonConvert.DeserializeObject<List<Level>>(json);
                
                return levelDto;
                //return JsonConvert.DeserializeObject<List<Level>>(json);
            }

            return JsonConvert.DeserializeObject(json, dtoType) ?? 
                   throw new NullReferenceException(nameof(json));
        }

        public void SaveData<T>(T dataModel, string key)
            where T : IDto
        {
            if (key == ModelId.GameLevels)
            {
                LevelDto levelDto = (LevelDto)(IDto)dataModel;
                
                string jsonLevels = JsonConvert.SerializeObject(levelDto.Levels, Formatting.Indented);
                PlayerPrefs.SetString(key, jsonLevels);

                return;
            }
            
            string json = JsonConvert.SerializeObject(dataModel) ?? 
                          throw new NullReferenceException(nameof(dataModel));
            
            PlayerPrefs.SetString(key, json);
        }

        public bool HasKey(string key) =>
            PlayerPrefs.HasKey(key);

        public void Clear(string key) =>
            PlayerPrefs.DeleteKey(key);

        public void SaveLevels(List<Level> levels, string key)
        {
            string json = JsonConvert.SerializeObject(levels, Formatting.Indented);
            PlayerPrefs.SetString(key, json);
        }

        public List<Level> LoadLevels(string key)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);
            
            return JsonConvert.DeserializeObject<List<Level>>(json);
        }
    }
}