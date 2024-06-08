using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ILevelDtoMapper
    {
        LevelDto MapModelToDto(Level level);
        Level MapDtoToModel(LevelDto levelDto);
    }
}