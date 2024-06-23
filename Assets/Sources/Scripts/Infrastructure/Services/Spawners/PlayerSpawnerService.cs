using System;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class PlayerSpawnerService : IPlayerSpawnerService
    {
        private readonly MainMenuPlayerViewFactory _playerViewFactory;
        private readonly MainMenuRootGameObjects _mainMenuRootGameObjects;
        private readonly IUpgradeService _upgradeService;

        private Player _player;

        public PlayerSpawnerService(
            MainMenuPlayerViewFactory playerViewFactory, 
            MainMenuRootGameObjects mainMenuRootGameObjects,
            IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
            _mainMenuRootGameObjects = mainMenuRootGameObjects ? mainMenuRootGameObjects : 
                throw new ArgumentNullException(nameof(mainMenuRootGameObjects));
        }

        public void Enable()
        {
            _upgradeService.LevelChanged += Spawn;
        }

        public void Disable()
        {
            _upgradeService.LevelChanged += Spawn;
        }
        
        public IPlayerView Spawn(Player player, int level)
        {
            _player = player;
            
            IPlayerView playerView = _playerViewFactory.Create(player, level, _mainMenuRootGameObjects.PlayerSpawnPoint);

            return playerView;
        }

        private void Spawn(int level)
        {
            if(_player == null)
                return;

            _playerViewFactory.Create(_player, level, _mainMenuRootGameObjects.PlayerSpawnPoint);
        }
    }
}