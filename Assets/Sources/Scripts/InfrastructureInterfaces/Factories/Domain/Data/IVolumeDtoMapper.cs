using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Settings;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IVolumeDtoMapper
    {
        VolumeDto MapModelToDto(Volume volume);
        Volume MapDtoToModel(VolumeDto volumeDto);
    }
}