using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Players;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ISkinChangerDtoMapper
    {
        SkinChangerDto MapModelToDto(SkinChanger skinChanger);
        SkinChanger MapDtoToModel(SkinChangerDto skinChangerDto);
    }
}