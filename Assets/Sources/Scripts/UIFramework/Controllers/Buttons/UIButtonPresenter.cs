using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Controllers.Presenters;
using Sources.Scripts.UIFramework.Presentations.Buttons.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Controllers.Buttons
{
    public class UIButtonPresenter : PresenterBase
    {
        private readonly IUIButtonService _uiButtonService;
        private readonly IUIButton _view;

        private CancellationTokenSource _cancellationTokenSource;

        public UIButtonPresenter(
            IUIButton view,
            IUIButtonService uiButtonService)
        {
            _uiButtonService = uiButtonService ??
                               throw new ArgumentNullException(nameof(uiButtonService));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        
        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _view.AddClickListener(ShowForm);
            _uiButtonService.Handle(_view.EnableCommandId, _view);
        }

        public override void Disable()
        {
            _view.RemoveClickListener(ShowForm);
            _uiButtonService.Handle(_view.DisableCommandId, _view);
            _cancellationTokenSource.Cancel();
        }

        private async void ShowForm()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (_view.UseButtonType == UseButtonType.Delayed)
                    await UniTask.Delay(TimeSpan.FromMilliseconds(_view.Delay),
                        cancellationToken: _cancellationTokenSource.Token,
                        ignoreTimeScale: true);
                
                _uiButtonService.Handle(_view.OnClickCommandId, _view);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}