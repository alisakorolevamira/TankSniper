using System;
using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Infrastructure.Factories.Views.Common
{
    public class HealthUITextViewFactory
    {
        private readonly HealthUITextPresenterFactory _presenterFactory;

        public HealthUITextViewFactory(HealthUITextPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IHealthUIText Create(IHealth health, HealthUIText healthIText)
        {
            HealthUITextPresenter presenter = _presenterFactory.Create(health, healthIText);

            healthIText.Construct(presenter);

            return healthIText;
        }
    }
}