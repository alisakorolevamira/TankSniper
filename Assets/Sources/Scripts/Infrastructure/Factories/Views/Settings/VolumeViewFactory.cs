using System;
using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Settings;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Infrastructure.Factories.Views.Settings
{
    public class VolumeViewFactory
    {
        private readonly VolumePresenterFactory _presenterFactory;

        public VolumeViewFactory(VolumePresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IVolumeView Create(Volume volume, VolumeView volumeView)
        {
            VolumePresenter presenter = _presenterFactory.Create(volume, volumeView);
            
            volumeView.Construct(presenter);
            
            return volumeView;
        }
    }
}