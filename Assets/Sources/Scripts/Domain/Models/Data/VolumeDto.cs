using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;

namespace Sources.Scripts.Domain.Models.Data
{
    public class VolumeDto : IDto
    {
        [JsonProperty("audioValue")]
        public int AudioValue { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}