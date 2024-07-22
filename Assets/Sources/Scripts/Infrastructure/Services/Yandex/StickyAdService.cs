using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;

namespace Sources.Scripts.Infrastructure.Services.Yandex
{
    public class StickyAdService : IStickyAdService
    {
        public void ShowStickyAd()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            StickyAd.Show();
        }
    }
}