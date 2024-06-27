using System;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;

namespace Sources.Scripts.Infrastructure.Services.Shop
{
    public class SkinChangerService : ISkinChangerService
    {
        private SkinChanger _skinChanger;

        public void ChangeSkin(int level) => 
            _skinChanger.ChangeSkin(level);
        
        public void Construct(SkinChanger skinChanger) => 
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));
    }
}