using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ISavedLevelDtoMapper
    {
        SavedLevelDto MapModelToDto(SavedLevel savedLevel);
        SavedLevel MapDtoToModel(SavedLevelDto savedLevelDto);
    }
}