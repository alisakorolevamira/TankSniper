using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class VolumeDtoMapper : IVolumeDtoMapper
    {
        public VolumeDto MapModelToDto(Volume volume)
        {
            return new VolumeDto()
            {
                AudioValue = volume.AudioVolume,
                Id = volume.Id,
            };
        }

        public Volume MapDtoToModel(VolumeDto volumeDto) =>
            new(volumeDto);
    }
}