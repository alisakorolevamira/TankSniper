using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class SkinChangerPresenterFactory
    {
        public SkinChangerPresenter Create(SkinChanger skinChanger, ISkinChangerView skinChangerView) => 
            new(skinChanger, skinChangerView);
    }
}