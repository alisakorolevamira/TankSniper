using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class LevelDtoMapper : ILevelDtoMapper
    {
        public LevelDto MapModelToDto(GameLevels levels)
        {
            return new LevelDto()
            {
                Id = levels.Id,
                Levels = levels.Levels,
            };
        }

        public GameLevels MapDtoToModel(LevelDto levelsDto)
        {
            return new(levelsDto.Id, levelsDto.Levels);
        }
    }
}