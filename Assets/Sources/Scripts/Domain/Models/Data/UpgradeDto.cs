using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;

namespace Sources.Scripts.Domain.Models.Data
{
    public class UpgradeDto : IDto
    {
        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public SkinType CurrentSkinType { get; set; }
    }
}