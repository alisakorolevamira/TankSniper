using System.Collections.Generic;
using System.Collections.Specialized;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.Domain.Models.Data
{
    public class LevelDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("levels")]
        public List<Level> Levels { get; set; }
        
        //[JsonProperty("isCompleted")]
        //public bool IsCompleted { get; set; }
        //
        //[JsonProperty("index")]
        //public int Index { get; set; }
    }
}