using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class CurrentLevelDto : IDto
    {
        //[JsonProperty("id")]
        public string Id { get; set; }
        
        //[JsonProperty("savedLevelId")]
        public string CurrentLevelId { get; set; }
    }
}