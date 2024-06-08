using System;
using Sources.Scripts.ControllersInterfaces.Presenters;

namespace Sources.Scripts.UIFramework.Presentations.Buttons
{
    public class PresentableUIButton<T> : UIButtonSoundView where T : IPresenter
    {
        protected T Presenter { get; private set; }

        protected override void OnAfterEnable()
        {
            Presenter?.Enable();
        }

        protected override void OnAfterDisable()
        {
            Presenter?.Disable();
        }

        public void Construct(T presenter)
        {
            Hide();
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            Show();
        }
    }
}