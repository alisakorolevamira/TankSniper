using System;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;

namespace Sources.Scripts.Infrastructure.Services.Yandex
{
    public class PlayerAccountAuthorizeService : IPlayerAccountAuthorizeService
    {
        public bool IsAuthorized()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return false;

            if (PlayerAccount.IsAuthorized == false)
                return false;

            return true;
        }

        public void Authorize(Action onSuccessCallback)
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            if (PlayerAccount.IsAuthorized)
                return;

            PlayerAccount.Authorize(onSuccessCallback);
        }
    }
}