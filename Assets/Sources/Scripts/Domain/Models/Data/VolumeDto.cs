using Sources.Scripts.DomainInterfaces.Models.Data;

namespace Sources.Scripts.Domain.Models.Data
{
    public class VolumeDto : IDto
    {
        //[JsonProperty("audioValue")]
        public int AudioValue { get; set; }
    }
}