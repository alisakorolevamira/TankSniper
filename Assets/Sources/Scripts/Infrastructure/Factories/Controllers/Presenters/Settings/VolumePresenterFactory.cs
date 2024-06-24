using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Settings
{
    public class VolumePresenterFactory
    {
        public VolumePresenter Create(IVolumeService volumeService, IVolumeView volumeView) =>
            new(volumeService, volumeView);
    }
}