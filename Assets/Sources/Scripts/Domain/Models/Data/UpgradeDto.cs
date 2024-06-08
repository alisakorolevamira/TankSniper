using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class UpgradeDto : IDto
    {
        //[JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        
        //[JsonProperty("id")]
        public string Id { get; set; }
    }
}