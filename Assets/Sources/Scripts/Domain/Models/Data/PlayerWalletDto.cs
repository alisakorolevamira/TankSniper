using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;

namespace Sources.Scripts.Domain.Models.Data
{
    public class PlayerWalletDto : IDto
    {
        [JsonProperty("money")]
        public int Money { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}