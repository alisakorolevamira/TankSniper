using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ITutorialDtoMapper
    {
        TutorialDto MapModelToDto(Tutorial tutorial);
        Tutorial MapDtoToModel(TutorialDto tutorialDto);
    }
}