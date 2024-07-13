using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;
using Sources.Scripts.UIFramework.Presentations.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shops
{
    public class ShopStickmanButtonView : View, IShopStickmanButtonView
    {
        [SerializeField] private UIButton _button;
        [SerializeField] private ImageView _icon;
        [SerializeField] private int _level;

        public int Level => _level;

        public void Hide()
        {
            _button.enabled = false;
            _button.SetState(UISelectionState.Disabled);
            _icon.HideImage();
        }

        public void Show()
        {
            _button.enabled = true;
            _button.SetState(UISelectionState.Normal);
            _icon.ShowImage();
        }
    }
}