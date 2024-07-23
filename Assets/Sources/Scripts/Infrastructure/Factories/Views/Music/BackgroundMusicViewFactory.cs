using System;
using Sources.Scripts.Controllers.Presenters.Music;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Music;
using Sources.Scripts.Presentations.Views.Music;
using Sources.Scripts.PresentationsInterfaces.Views.Music;

namespace Sources.Scripts.Infrastructure.Factories.Views.Music
{
    public class BackgroundMusicViewFactory
    {
        private readonly BackgroundMusicPresenterFactory _presenterFactory;

        public BackgroundMusicViewFactory(BackgroundMusicPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IBackgroundMusicView Create(BackgroundMusicView backgroundMusicView)
        {
            BackgroundMusicPresenter presenter = _presenterFactory.Create(backgroundMusicView);
            backgroundMusicView.Construct(presenter);
            
            return backgroundMusicView;
        }
    }
}