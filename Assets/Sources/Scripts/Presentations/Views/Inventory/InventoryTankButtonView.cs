using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventoryTankButtonView : PresentableView<InventoryTankButtonPresenter>, IInventoryTankButtonView
    {
        [SerializeField] private UIButton _button;
        [SerializeField] private UIText _priceText;
        [SerializeField] private UIText _freeText;
        [SerializeField] private ImageView _moneyIcon;
        [SerializeField] private ImageView _adImage;

        public UIButton Button => _button;
        public UIText PriceText => _priceText;
        public UIText FreeText => _freeText;
        public ImageView MoneyIcon => _moneyIcon;
        public ImageView AdImage => _adImage;
    }
}