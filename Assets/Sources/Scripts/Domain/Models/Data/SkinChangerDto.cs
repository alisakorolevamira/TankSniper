using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;

namespace Sources.Scripts.Domain.Models.Data
{
    public class SkinChangerDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public SkinType CurrentSkinType { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public MaterialType CurrentMaterialType { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public DecalType CurrentDecalType { get; set; }
    }
}