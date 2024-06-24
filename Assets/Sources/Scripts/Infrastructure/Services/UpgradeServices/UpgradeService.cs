using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;

namespace Sources.Scripts.Infrastructure.Services.UpgradeServices
{
    public class UpgradeService : IUpgradeService
    {
        private readonly ITutorialService _tutorialService;
        
        private Upgrader _upgrader;

        public UpgradeService(ITutorialService tutorialService)
        {
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
        }
        
        public event Action<int> LevelChanged;

        public void Register(Upgrader upgrader) => 
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));

        public void CheckLevel(int level)
        {
            if (level > _upgrader.CurrentLevel)
            {
                _upgrader.Upgrade();
                LevelChanged?.Invoke(_upgrader.CurrentLevel);

                if (_tutorialService.IsCompleted == false)
                    Signal.Send(StreamId.MainMenu.ShowFightTutorial);
            }
        }
    }
}