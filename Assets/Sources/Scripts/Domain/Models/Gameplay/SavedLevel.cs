using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class SavedLevel : IEntity
    {
        public SavedLevel(SavedLevelDto savedLevelDto)
        {
            Id = savedLevelDto.Id;
            CurrentLevelId = savedLevelDto.SavedLevelId;
        }

        public SavedLevel(string id, string currentLevelId)
        {
            Id = id;
            CurrentLevelId = currentLevelId;
        }
        
        public string Id { get; }
        public string CurrentLevelId { get; set; }
        public Type Type => GetType();
    }
}