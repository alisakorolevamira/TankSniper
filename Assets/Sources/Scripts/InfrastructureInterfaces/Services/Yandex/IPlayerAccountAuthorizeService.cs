using System;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Yandex
{
    public interface IPlayerAccountAuthorizeService
    {
        bool IsAuthorized();
        void Authorize(Action onSuccessCallback);
    }
}