using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class LevelDtoMapper : ILevelDtoMapper
    {
        public LevelDto MapModelToDto(Level level)
        {
            return new LevelDto()
            {
                Id = level.Id,
                IsCompleted = level.IsCompleted,
            };
        }

        public Level MapDtoToModel(LevelDto levelDto) =>
            new(levelDto.Id, levelDto.IsCompleted);
    }
}