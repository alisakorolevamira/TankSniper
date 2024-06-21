using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;

namespace Sources.Scripts.Domain.Models.Data
{
    public class SavedLevelDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("savedLevelId")]
        public string SavedLevelId { get; set; }
    }
}