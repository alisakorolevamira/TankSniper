using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.Domain.Models.Data
{
    public class ShopPatternButtonDto : IDto
    {
        [JsonProperty("isBought")]
        public bool IsBought { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MaterialType MaterialType { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}