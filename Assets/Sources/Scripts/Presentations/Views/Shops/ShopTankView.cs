using Sources.Scripts.PresentationsInterfaces.Views.Shops;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shops
{
    public class ShopTankView : View, IShopTankView
    {
        [SerializeField] private int _level;

        public int Level => _level;

        private void Awake() => 
            Hide();
    }
}