using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Shop
{
    public class StickmanChangerService : IStickmanChangerService
    {
        private readonly IEntityRepository _entityRepository;
        
        private StickmanChanger _stickmanChanger;

        public StickmanChangerService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public event Action<int> StickmanOpened;

        public void Enable() =>
            ShowStickmanForDron();

        public void Construct(StickmanChanger stickmanChanger) => 
            _stickmanChanger = stickmanChanger ?? throw new ArgumentNullException(nameof(stickmanChanger));
        
        public void ChangeStickman(StickmanType stickmanType) => 
            _stickmanChanger.ChangeStickman(stickmanType);

        public void OpenNewStickman()
        {
            int newLevel = _stickmanChanger.Level + 1;

            if (newLevel <= StickmanConst.MaxStickmen)
            {
                StickmanOpened?.Invoke(newLevel);
                _stickmanChanger.EnableNewStickman();
            }
        }

        private void ShowStickmanForDron()
        {
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);

            switch (savedLevel.CurrentLevelId)
            {
                case LevelConst.EleventhLevel:
                    ChangeStickman(_stickmanChanger.CurrentStickman == StickmanType.Default
                        ? StickmanType.Doctor
                        : _stickmanChanger.CurrentStickman);
                    break;
                
                case LevelConst.SeventeenthLevel:
                    ChangeStickman(_stickmanChanger.CurrentStickman == StickmanType.Default
                        ? StickmanType.Doctor
                        : _stickmanChanger.CurrentStickman);
                    break;
            }
        }
    }
}