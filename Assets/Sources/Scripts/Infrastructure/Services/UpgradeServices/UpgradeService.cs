using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.UpgradeServices
{
    public class UpgradeService : IUpgradeService
    {
        private readonly IFormService _formService;
        
        private Upgrader _upgrader;

        public UpgradeService(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
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
                
                if (_formService.IsActive(FormId.MergeTanksTutorial))
                    _formService.Show(FormId.FightTutorial);
            }
        }
    }
}