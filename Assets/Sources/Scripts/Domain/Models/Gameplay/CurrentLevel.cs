﻿using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class CurrentLevel : IEntity
    {
        public CurrentLevel(CurrentLevelDto currentLevelDto)
        {
            Id = currentLevelDto.Id;
            CurrentLevelId = currentLevelDto.CurrentLevelId;
        }

        public CurrentLevel(string id, string currentLevelId)
        {
            Id = id;
            CurrentLevelId = currentLevelId;
        }
        
        public string Id { get; }
        public string CurrentLevelId { get; set; }
        public Type Type => GetType();
    }
}