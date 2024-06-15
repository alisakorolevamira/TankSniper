﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.PresentationsInterfaces.Views.Items;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Services.LevelCompleted
{
    public class LevelCompletedService : ILevelCompletedService
    {
        private readonly IFormService _formService;
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;
        //private readonly IInterstitialAdService _interstitialAdService;
        private IKilledEnemiesCounter _killedEnemiesCounter;
        private IEnemySpawner _enemySpawner;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(2);
        
        public LevelCompletedService(
            IFormService formService,
            IEntityRepository entityRepository,
            ILoadService loadService)
            //IInterstitialAdService interstitialAdService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            //_interstitialAdService = interstitialAdService ?? 
            //                         throw new ArgumentNullException(nameof(interstitialAdService));
        }
        
        public bool AllEnemiesKilled { get; private set; }

        public void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _killedEnemiesCounter.KilledEnemiesCountChanged += OnKillZombiesCountChanged;
        }

        public void Disable() =>
            _killedEnemiesCounter.KilledEnemiesCountChanged -= OnKillZombiesCountChanged;

        public void Register(IKilledEnemiesCounter killedEnemiesCounter, IEnemySpawner enemySpawner)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnKillZombiesCountChanged()
        {
            if (_killedEnemiesCounter.KilledEnemies < _enemySpawner.SpawnedEnemies)
                return;

            AllEnemiesKilled = true;
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.CurrentLevel);
            Level level = _entityRepository.Get<Level>(savedLevel.CurrentLevelId);
            level.Complete();
            _loadService.Save(level);
            _loadService.ClearAll();
            //StartTimer(_cancellationTokenSource.Token);
            //_interstitialAdService.ShowInterstitial();
        }

        private async void StartTimer(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                
                _formService.Show(FormId.LevelCompleted);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}