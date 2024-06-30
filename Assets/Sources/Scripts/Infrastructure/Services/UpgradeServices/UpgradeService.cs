using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;

namespace Sources.Scripts.Infrastructure.Services.UpgradeServices
{
    public class UpgradeService : IUpgradeService
    {
        private readonly ITutorialService _tutorialService;
        
        private Upgrader _upgrader;
        private SkinChanger _skinChanger;

        public UpgradeService(ITutorialService tutorialService)
        {
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
        }
        
        public event Action<int> LevelChanged;

        public void Register(Upgrader upgrader, SkinChanger skinChanger)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));
        }

        public void CheckLevel(int level)
        {
            if (level > _upgrader.CurrentLevel)
            {
                _upgrader.Upgrade();
                SkinType skinType = (SkinType)level;
                _skinChanger.ChangeSkin(skinType);

                LevelChanged?.Invoke(_upgrader.CurrentLevel);

                if (_tutorialService.IsCompleted == false)
                    Signal.Send(StreamId.MainMenu.ShowFightTutorial);
            }
        }
    }
}