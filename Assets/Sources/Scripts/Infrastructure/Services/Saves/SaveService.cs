using System;
using System.Threading;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;

namespace Sources.Scripts.Infrastructure.Services.Saves
{
    public class SaveService : ISaveService
    {
        private readonly ILoadService _loadService;
        private readonly TimeSpan _showedFormDelay = TimeSpan.FromSeconds(5f); //вынести в константу
        
        private IEnemySpawner _enemySpawner;
        private CancellationTokenSource _cancellationTokenSource;

        public SaveService(ILoadService loadService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enter(object payload = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }
        
        public void Register(IEnemySpawner enemySpawner) =>
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
    }
}