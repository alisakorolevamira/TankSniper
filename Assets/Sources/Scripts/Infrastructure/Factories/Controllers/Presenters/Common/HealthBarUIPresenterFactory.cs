using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common
{
    public class HealthBarUIPresenterFactory
    {
        public HealthBarUIPresenter Create(IHealth health, IHealthBarUI healthBarUI) => 
            new(health, healthBarUI);
    }
}