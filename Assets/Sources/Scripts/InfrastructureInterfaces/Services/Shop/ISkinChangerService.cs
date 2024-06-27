using Sources.Scripts.Domain.Models.Players;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Shop
{
    public interface ISkinChangerService
    {
        void ChangeSkin(int level);
        void Construct(SkinChanger skinChanger);
    }
}