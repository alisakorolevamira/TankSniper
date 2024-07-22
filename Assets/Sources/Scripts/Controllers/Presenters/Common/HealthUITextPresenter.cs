using System;
using System.Threading;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.DomainInterfaces.Models.Healths;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Controllers.Presenters.Common
{
    public class HealthUITextPresenter : PresenterBase
    {
        private readonly IHealth _health;
        private readonly IHealthUIText _healthUIText;

        private CancellationTokenSource _cancellationTokenSource;

        public HealthUITextPresenter(IHealth health, IHealthUIText healthUIText)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healthUIText = healthUIText ?? throw new ArgumentNullException(nameof(healthUIText));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _healthUIText.DamageText.SetText(string.Empty);
            
            _health.DamageReceived += OnDamageReceived;
        }

        public override void Disable()
        {
            _health.DamageReceived -= OnDamageReceived;
            
            _cancellationTokenSource.Cancel();
        }

        private void OnDamageReceived(float damage)
        {
            _healthUIText.DamageText.SetTextColor(DamageTextConst.ShowedColor);
            _healthUIText.DamageText.SetIsHide(false);
            _healthUIText.DamageText.SetText(damage.ToString());
            _healthUIText.DamageText.SetClearColorAsync(_cancellationTokenSource.Token);
        }
    }
}