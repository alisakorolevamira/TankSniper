using System;
using System.Collections.Generic;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameLevels : IEntity
    {
        public GameLevels(string id, List<Level> levels)
        {
            Id = id;
            Levels = levels;
        }
        
        public string Id { get; }
        public Type Type => GetType();
        public List<Level> Levels { get; set; }
    }
}