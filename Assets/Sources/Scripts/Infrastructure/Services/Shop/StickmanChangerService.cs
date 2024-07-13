using System;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Stickman;

namespace Sources.Scripts.Infrastructure.Services.Shop
{
    public class StickmanChangerService : IStickmanChangerService
    {
        private StickmanChanger _stickmanChanger;
        
        public void Construct(StickmanChanger stickmanChanger) => 
            _stickmanChanger = stickmanChanger ?? throw new ArgumentNullException(nameof(stickmanChanger));
        
        public void ChangeStickman(StickmanType stickmanType) => 
            _stickmanChanger.ChangeStickman(stickmanType);
    }
}