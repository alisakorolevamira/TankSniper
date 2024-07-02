using System;
using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Infrastructure.Factories.Views.Common
{
    public class HealthBarUIFactory
    {
        private readonly HealthBarUIPresenterFactory _healthBarUIPresenterFactory;

        public HealthBarUIFactory(HealthBarUIPresenterFactory healthBarUIPresenterFactory)
        {
            _healthBarUIPresenterFactory = healthBarUIPresenterFactory ??
                                           throw new ArgumentNullException(nameof(healthBarUIPresenterFactory));
        }

        public IHealthBarUI Create(IHealth health, HealthBarUI healthBarUI)
        {
            HealthBarUIPresenter healthBarUIPresenter = _healthBarUIPresenterFactory.Create(health, healthBarUI);

            healthBarUI.Construct(healthBarUIPresenter);

            return healthBarUI;
        }
    }
}