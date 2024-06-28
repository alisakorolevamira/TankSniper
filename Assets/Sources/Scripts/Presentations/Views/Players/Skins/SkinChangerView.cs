using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players.Skins
{
    public class SkinChangerView : PresentableView<SkinChangerPresenter>, ISkinChangerView
    {
        [SerializeField] private List<SkinView> _skinViews;

        private Dictionary<SkinType, SkinView> _skins;

        public IReadOnlyDictionary<SkinType, SkinView> Skins => _skins;
        public SkinView CurrentSkinView { get; private set; }

        private void Awake()
        {
            _skins = _skinViews.ToDictionary(skin => skin.SkinType, skin => skin);
        }

        public void SetCurrentSkin(SkinType skinType)
        {
            CurrentSkinView = _skins[skinType];
        }
    }
}