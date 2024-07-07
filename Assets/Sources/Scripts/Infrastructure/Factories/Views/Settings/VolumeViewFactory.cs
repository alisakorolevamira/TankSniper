using System;
using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Infrastructure.Factories.Views.Settings
{
    public class VolumeViewFactory
    {
        private readonly VolumePresenterFactory _presenterFactory;

        public VolumeViewFactory(VolumePresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IVolumeView Create(IVolumeService volumeService, VolumeView volumeView)
        {
            VolumePresenter presenter = _presenterFactory.Create(volumeService, volumeView);
            
            volumeView.Construct(presenter);
            
            return volumeView;
        }
    }
}