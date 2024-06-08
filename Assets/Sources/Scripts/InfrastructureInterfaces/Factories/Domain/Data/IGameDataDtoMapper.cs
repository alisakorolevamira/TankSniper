using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IGameDataDtoMapper
    {
        GameDataDto MapModelToDto(GameData gameData);
        GameData MapDtoToModel(GameDataDto gameDataDto);
    }
}