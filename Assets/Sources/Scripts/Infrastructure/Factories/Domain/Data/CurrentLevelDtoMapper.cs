using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class CurrentLevelDtoMapper : ICurrentLevelDtoMapper
    {
        public CurrentLevelDto MapModelToDto(CurrentLevel savedLevel)
        {
            return new CurrentLevelDto()
            {
                Id = savedLevel.Id,
                CurrentLevelId = savedLevel.CurrentLevelId,
            };
        }

        public CurrentLevel MapDtoToModel(CurrentLevelDto savedLevelDto) =>
            new(savedLevelDto);
    }
}