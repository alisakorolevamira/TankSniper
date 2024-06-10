using System;
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
        
        public void Enable() =>
            _killedEnemiesCounter.KilledEnemiesCountChanged += OnKillZombiesCountChanged;

        public void Disable() =>
            _killedEnemiesCounter.KilledEnemiesCountChanged -= OnKillZombiesCountChanged;

        public void Register(IKilledEnemiesCounter killedEnemiesCounter, IEnemySpawner enemySpawner)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            //_enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        }

        private void OnKillZombiesCountChanged()
        {
            //if (_killedEnemiesCounter.KilledEnemies < _enemySpawner.SpawnedEnemies)
                //return;

            CurrentLevel currentLevel = _entityRepository.Get<CurrentLevel>(ModelId.CurrentLevel);
            Level level = _entityRepository.Get<Level>(currentLevel.CurrentLevelId);
            level.Complete();
            _loadService.Save(level);
            _loadService.ClearAll();
            _formService.Show(FormId.LevelCompleted);
            //_interstitialAdService.ShowInterstitial();
        }
    }
}