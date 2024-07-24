using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class ShowInterstitialAdCommand : IButtonCommand
    {
        private readonly IInterstitialAdService _interstitialAdService;

        public ShowInterstitialAdCommand(IInterstitialAdService interstitialAdService)
        {
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
        }

        public ButtonCommandId Id => ButtonCommandId.ShowAd;
        
        public void Handle() => 
            _interstitialAdService.ShowInterstitialAd();
    }
}