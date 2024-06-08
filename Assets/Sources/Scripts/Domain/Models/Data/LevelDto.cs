using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class LevelDto : IDto
    {
        //[JsonProperty("id")]
        public string Id { get; set; }
        
        //[JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}