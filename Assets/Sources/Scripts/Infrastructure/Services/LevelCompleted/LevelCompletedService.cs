using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;

namespace Sources.Scripts.Infrastructure.Services.LevelCompleted
{
    public class LevelCompletedService : ILevelCompletedService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;
        private IKilledEnemiesCounter _killedEnemiesCounter;
        private IEnemySpawner _enemySpawner;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(4);
        
        public LevelCompletedService(
            IEntityRepository entityRepository,
            ILoadService loadService)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public event Action<int> LevelCompleted;
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

            int reward = _enemySpawner.SpawnedEnemies * PlayerConst.RewardCoefficient;
            
            LevelCompleted?.Invoke(reward);
            PlayerWallet playerWallet = _entityRepository.Get<PlayerWallet>(ModelId.PlayerWallet);
            playerWallet.AddMoney(reward);
            
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            GameLevels gameLevels = _entityRepository.Get<GameLevels>(ModelId.GameLevels);
            Level level = gameLevels.Levels.Find(level => level.Id == savedLevel.CurrentLevelId);
            
            level.Complete();
            CheckMenuIndex(level);

            if (level.Id == LevelConst.EighteenthLevel)
            {
                gameLevels.SetClearLevels();
                savedLevel.Clear();
            }
            
            _loadService.SaveAll();
            
            StartTimer(_cancellationTokenSource.Token);
        }

        private async void StartTimer(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                
                Signal.Send(StreamId.Gameplay.LevelCompleted);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void CheckMenuIndex(Level level)
        {
            MainMenuAppearance mainMenu = _entityRepository.Get<MainMenuAppearance>(ModelId.MainMenuAppearance);

            if (level.Id == LevelConst.SixthLevel)
                mainMenu.Index = MainMenuConst.SecondView;
            
            else if (level.Id == LevelConst.TwelfthLevel) 
                mainMenu.Index = MainMenuConst.ThirdView;
            
            else if (level.Id == LevelConst.EighteenthLevel)
                mainMenu.Index = MainMenuConst.FirstView;
        }
    }
}