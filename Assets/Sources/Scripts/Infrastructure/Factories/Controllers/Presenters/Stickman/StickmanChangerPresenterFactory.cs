using Sources.Scripts.Controllers.Presenters.Stickman;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.PresentationsInterfaces.Views.Stickman;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Stickman
{
    public class StickmanChangerPresenterFactory
    {
        public StickmanChangerPresenter Create(StickmanChanger stickmanChanger, IStickmanChangerView view) => 
            new(stickmanChanger, view);
    }
}