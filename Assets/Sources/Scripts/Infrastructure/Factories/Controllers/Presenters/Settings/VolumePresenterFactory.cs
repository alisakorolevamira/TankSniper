using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Settings
{
    public class VolumePresenterFactory
    {
        public VolumePresenter Create(Volume volume, IVolumeView volumeView) =>
            new(volume, volumeView);
    }
}