using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.Utils.Extentions;

namespace Sources.Scripts.Controllers.Presenters.Common
{
    public class HealthBarUIPresenter : PresenterBase
    {
        private readonly IHealth _health;
        private readonly IHealthBarUI _healthBarUI;

        public HealthBarUIPresenter(IHealth health, IHealthBarUI healthBarUI)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healthBarUI = healthBarUI ?? throw new ArgumentNullException(nameof(healthBarUI));
        }

        public override void Enable()
        {
            OnHealthChanged();
            _health.HealthChanged += OnHealthChanged;
        }

        public override void Disable() =>
            _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged()
        {
            float percent = _health.CurrentHealth.FloatToPercent(_health.MaxHealth);
            float fillAmount = percent * MathConst.UnitMultiplier;
            
            _healthBarUI.HealthImage.SetFillAmount(fillAmount);
        }
    }
}