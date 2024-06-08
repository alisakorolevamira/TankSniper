using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ICurrentLevelDtoMapper
    {
        CurrentLevelDto MapModelToDto(CurrentLevel savedLevel);
        CurrentLevel MapDtoToModel(CurrentLevelDto savedLevelDto);
    }
}