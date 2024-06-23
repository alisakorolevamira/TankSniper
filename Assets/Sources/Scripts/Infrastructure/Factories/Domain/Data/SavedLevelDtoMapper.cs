using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class SavedLevelDtoMapper : ISavedLevelDtoMapper
    {
        public SavedLevelDto MapModelToDto(SavedLevel savedLevel)
        {
            return new SavedLevelDto()
            {
                Id = savedLevel.Id,
                SavedLevelId = savedLevel.CurrentLevelId
            };
        }

        public SavedLevel MapDtoToModel(SavedLevelDto savedLevelDto) =>
            new(savedLevelDto.Id, savedLevelDto.SavedLevelId);
    }
}