using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class GameDataDto : IDto
    {
        //[JsonProperty("id")]
        public string Id { get; set; }
        
        //[JsonProperty("wasLaunched")]
        public bool WasLaunched { get; set; }
    }
}