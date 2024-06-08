using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class PlayerWalletDto : IDto
    {
        //[JsonProperty("coins")]
        public int Money { get; set; }
        
        //[JsonProperty("id")]
        public string Id { get; set; }
    }
}