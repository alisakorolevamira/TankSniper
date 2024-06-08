using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Controllers.Presenters.Gameplay
{
    public class KilledEnemiesCounterPresenter : PresenterBase
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IKilledEnemiesCounterView _killedEnemiesCounterView;

        public KilledEnemiesCounterPresenter(
            KilledEnemiesCounter killEnemyCounter,
            IEnemySpawner enemySpawner,
            IKilledEnemiesCounterView killEnemyCounterView)
        {
            _killedEnemiesCounter = killEnemyCounter ?? 
                                throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _killedEnemiesCounterView = killEnemyCounterView ??
                                        throw new ArgumentNullException(nameof(killEnemyCounterView));
        }

        public override void Enable()
        {
            OnKilledEnemiesCountChanged();
            _killedEnemiesCounter.KilledEnemiesCountChanged += OnKilledEnemiesCountChanged;
        }

        public override void Disable() =>
            _killedEnemiesCounter.KilledEnemiesCountChanged -= OnKilledEnemiesCountChanged;

        private void OnKilledEnemiesCountChanged()
        {
            string killedEnemies = $"{_killedEnemiesCounter.KilledEnemies}/{_enemySpawner.AllEnemies}";
            _killedEnemiesCounterView.KilledEnemiesUIText.SetText(killedEnemies);
        }
    }
}