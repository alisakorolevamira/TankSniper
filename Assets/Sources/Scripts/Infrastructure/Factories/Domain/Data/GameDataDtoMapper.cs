using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class GameDataDtoMapper : IGameDataDtoMapper
    {
        public GameDataDto MapModelToDto(GameData gameData)
        {
            return new GameDataDto()
            {
                Id = gameData.Id,
                WasLaunched = gameData.WasLaunched
            };
        }

        public GameData MapDtoToModel(GameDataDto gameDataDto) =>
            new(gameDataDto);
    }
}