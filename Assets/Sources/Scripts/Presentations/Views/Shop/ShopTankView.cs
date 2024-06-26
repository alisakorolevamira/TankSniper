using System;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shop
{
    public class ShopTankView : View, IShopTankView
    {
        [SerializeField] private int _level;

        public int Level => _level;

        private void Awake() => 
            Hide();
    }
}