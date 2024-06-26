using System;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class SkinChangerPresenter : PresenterBase
    {
        private readonly SkinChanger _skinChanger;
        private readonly ISkinChangerView _skinChangerView;

        public SkinChangerPresenter(SkinChanger skinChanger, ISkinChangerView skinChangerView)
        {
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));
            _skinChangerView = skinChangerView ?? throw new ArgumentNullException(nameof(skinChangerView));
        }


        public override void Enable()
        {
            OnSkinChanged();
            _skinChanger.CurrentSkinChanged += OnSkinChanged;
        }

        public override void Disable()
        {
            _skinChanger.CurrentSkinChanged -= OnSkinChanged;
        }

        private void OnSkinChanged()
        {
            HideAllSkins();
            _skinChangerView.Skins[_skinChanger.CurrentSkin].Show();
        }

        private void HideAllSkins()
        {
            foreach (SkinView skinView in _skinChangerView.Skins.Values) 
                skinView.Hide();
        }
    }
}